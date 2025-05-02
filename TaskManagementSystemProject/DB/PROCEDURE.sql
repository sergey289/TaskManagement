
--ADD NEW TASK PROCEDURE

CREATE PROCEDURE Proc_Get_All_Tasks 

AS
BEGIN
    SELECT  t.Task_Id, t.Title, t.[Description],s.Name as StatusName,t.CreatedBy,t.AssignedTo,t.CreatedAt,t.UpdatedAt	
    FROM Tasks t
    JOIN [Status] s ON t.Status_Id = s.Status_Id
END;


--GET STATUSES PROCEDURE

CREATE PROCEDURE Proc_Get_Statuses

AS

BEGIN

SELECT Status_Id,[Name]
FROM [Status]

END

-- ADD NEW TASK PROCEDURE

CREATE PROCEDURE Proc_Add_New_Task

@Title NVARCHAR(100),
@Description TEXT = NULL, -- Remove NOT NULL, make it optional
@Status_Id INT = 1,
@CreatedBy NVARCHAR(100),
@AssignedTo NVARCHAR(100) = NULL

AS

BEGIN

	INSERT INTO Tasks (Title,[Description],Status_Id,CreatedBy,AssignedTo)
	VALUES(@Title,@Description,@Status_Id,@CreatedBy,@AssignedTo)

END


-- UPDATE TASK PROCEDURE

CREATE OR ALTER PROCEDURE Proc_Update_Task
    @TaskId INT,
    @Title NVARCHAR(100) = NULL,
    @Description TEXT = NULL,
    @Status_Id INT = NULL,
	@CreatedBy NVARCHAR(100) = NULL,
    @AssignedTo NVARCHAR(100) = NULL
AS
BEGIN
       
    UPDATE Tasks
    SET 
        Title = ISNULL(@Title, Title),
        [Description] = ISNULL(@Description, [Description]),
        Status_Id = ISNULL(@Status_Id, Status_Id),
		CreatedBy = ISNULL(@CreatedBy, CreatedBy),
        AssignedTo = ISNULL(@AssignedTo, AssignedTo),
        UpdatedAt = GETDATE()  -- Track when the task was last modified
    WHERE 
        Task_Id = @TaskId;
END

-- DELETE TASK PROCEDURE

CREATE PROCEDURE Proc_Delete_Task

@TaskId INT

AS

IF  EXISTS (SELECT 1 FROM Tasks WHERE Task_Id = @TaskId)
    BEGIN
       DELETE FROM Tasks
       WHERE Task_Id = @TaskId
    END