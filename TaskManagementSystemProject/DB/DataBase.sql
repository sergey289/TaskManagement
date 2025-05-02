

CREATE DATABASE TaskManagementSystem;


-- Status table
CREATE TABLE [Status] (
    Status_Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(50) NOT NULL
);


INSERT INTO [Status] ([Name])
VALUES 
    ('To Do'),
    ('In Progress'),
    ('Done');


-- Task table
CREATE TABLE Tasks (
    Task_Id INT PRIMARY KEY IDENTITY(1,1), -- автоинкремент, если нужно
    Title VARCHAR(100) NOT NULL,
    [Description] TEXT,
    Status_Id INT NOT NULL,
    CreatedBy VARCHAR(100) NOT NULL, -- Лучше ограничить длину
    AssignedTo VARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE(), -- автозаполнение текущей даты
    UpdatedAt DATETIME,

    FOREIGN KEY (Status_Id) REFERENCES [Status](Status_Id)
);






















