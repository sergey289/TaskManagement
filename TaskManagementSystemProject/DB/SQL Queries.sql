
-- SQL Queries

--Get Tasks in the last week

 SELECT  t.Task_Id, t.Title, t.[Description],s.Name as StatusName,t.CreatedBy,t.AssignedTo,t.CreatedAt,t.UpdatedAt	
    FROM Tasks t
    JOIN [Status] s ON t.Status_Id = s.Status_Id
	WHERE 
		 CAST(t.CreatedAt AS date) >= DATEADD(day, -7, CAST(GETDATE() AS date))


--Calculate the number of tasks by status

SELECT 
    s.Name as StatusType, 
    COUNT(*) AS TaskCount
FROM Tasks t
JOIN status s ON t.Status_Id = s.Status_Id
GROUP BY s.Name

-- Average time in days between task creation and completion

SELECT 
    s.Name AS StatusName,
    AVG(DATEDIFF(day, t.CreatedAt, t.UpdatedAt)) AS AvgDaysToComplete
FROM Tasks t
JOIN Status s ON t.Status_Id = s.Status_Id
WHERE t.UpdatedAt IS NOT NULL
GROUP BY s.Name;




update Tasks
set UpdatedAt = DATEADD(DAY,+20,CreatedAt)
where Task_Id = 4




select *
from Tasks

select *
from Status



