﻿USE  UniversityDB;
GO

CREATE TABLE Groups
(
	GroupID INT PRIMARY KEY IDENTITY(1, 1),
	GroupName NVARCHAR(10) NOT NULL
);
GO

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY(1, 1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PatronymicName NVARCHAR(50) NOT NULL,
	Sex NVARCHAR(10) NOT NULL,
	BirthDate DATE NOT NULL,
	GroupID INT,

	CONSTRAINT FK_StudentGroup FOREIGN KEY (GroupID)
	REFERENCES Groups(GroupID)
);
GO

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY(1, 1),
	SubjectName NVARCHAR(70) NOT NULL
);
GO

CREATE TABLE Assessments
(
	AssessmentID INT PRIMARY KEY IDENTITY(1, 1),
	SubjectID INT,
	AssessmentDate DATE,
	StudentID INT,
	Result NVARCHAR(10),

	CONSTRAINT FK_AssessmentStudent FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),
	CONSTRAINT FK_AssessmentSubject FOREIGN KEY (SubjectID)
	REFERENCES Subjects(SubjectID)
);
GO


CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(1, 1),
	SubjectID INT,
	ExamDate DATE,
	StudentID INT,
	Mark INT,

	CONSTRAINT CHK_Mark CHECK (Mark >= 1 AND Mark <= 10),

	CONSTRAINT FK_ExamStudent FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),
	CONSTRAINT FK_ExamSubject FOREIGN KEY (SubjectID)
	REFERENCES Subjects(SubjectID)
);
GO