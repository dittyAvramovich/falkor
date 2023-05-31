alter procedure getDataQueue @date date, @floor_id int = NULL, @department_id int = NULL
as
begin
DECLARE @departmentsList VARCHAR(MAX);
DECLARE @pivotColumns NVARCHAR(MAX);

SELECT @departmentsList = STRING_AGG(department_desc, ','),
       @pivotColumns = STRING_AGG(QUOTENAME(department_desc), ',')
FROM key_departments dep
where (@department_id is null or dep.id = @department_id) and 
dep.id in 
(select department_id from rel_floors_departments 
where (@floor_id is null or floor_id = @floor_id))

DECLARE @sqlQuery NVARCHAR(MAX)
set @sqlQuery = N'
SELECT *
FROM (
    SELECT ROW_NUMBER() OVER (PARTITION BY department_desc, DATEADD(minute, DATEDIFF(minute, 0, schedule_time) / 30 * 30, 0) ORDER BY id) AS row_num,
           patient_id,
           patient_name, 
		   patient_phone,
		   SUBSTRING(patient_name, LEN(patient_name) - CHARINDEX('' '', REVERSE(patient_name)) + 1, LEN(patient_name)) + '', '' + 
		   LEFT(patient_name, 1) + ''.'' as disguised_name,
		   queue_number,
		   Doctor_Name,
		   payer,
		   schedule_time,
           department_desc,
           CAST(DATEADD(minute, DATEDIFF(minute, 0, schedule_time) / 30 * 30, 0) AS time) AS scheduled_time_interval
    FROM (
        SELECT data_queue.id,
			   patient_id,
               patient_name, 
			   patient_phone,
			   queue_number,
               schedule_time,
			   Doctor_Name,
			   payer,
               department_desc
        FROM data_queue
        JOIN key_departments k ON data_queue.department_id = k.id
        JOIN key_doctors d ON data_queue.doctor_number = d.doctor_number
		where schedule_date = ''' + CAST(@date as varchar(10)) + N'''
		and (floor_id = ' + ISNULL('''' + cast(@floor_id as varchar(MAX)) +'''', 'floor_id') + N') 
		and (department_id = ' + ISNULL('''' + cast(@department_id as varchar(MAX)) +'''', 'department_id') + N') 
		
    ) AS a
) AS b
PIVOT (
    MAX(patient_name)
    FOR department_desc IN (' + @pivotColumns + N')
) AS PivotTable
GROUP BY scheduled_time_interval, schedule_time, queue_number, ' + @pivotColumns + N', row_num, Doctor_Name, payer, disguised_name, patient_id, patient_phone'

EXECUTE sp_executesql @sqlQuery

end
go

EXECUTE getDataQueue @date='2022-02-18', @floor_id = 3