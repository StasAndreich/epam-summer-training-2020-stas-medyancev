CREATE DATABASE UniversityDB;
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
	Patronymic NVARCHAR(50) NOT NULL,
	Sex NVARCHAR(10) NOT NULL,
	BirthDate DATE NOT NULL,
	GroupID INT,

	CONSTRAINT FK_StudentGroup FOREIGN KEY (GroupID)
	REFERENCES Groups(GroupID)
);
GO


-- All Assessments tables.
CREATE TABLE Assessments
(
	AssessmentID INT PRIMARY KEY IDENTITY(1, 1),
	AssessmentNaming NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE AssessmentResults
(
	AssessmentResultID INT PRIMARY KEY IDENTITY(1, 1),
	StudentID INT NOT NULL,
	Verdict NVARCHAR(15),

	CONSTRAINT FK_AssessmentResultStudent FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID)
);
GO

CREATE TABLE AssessmentSets
(
	AssessmentSetID INT PRIMARY KEY IDENTITY(1, 1),
	AssessmentID INT NOT NULL,
	AssessmentDate DATE,
	AssessmentResultID INT,

	CONSTRAINT FK_AssessmentSetAssessment FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID)
);
GO


-- All Exams tables.
CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(1, 1),
	ExamNaming NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE ExamResults
(
	ExamResultID INT PRIMARY KEY IDENTITY(1, 1),
	StudentID INT NOT NULL,
	Mark INT,

	CONSTRAINT CHK_Mark CHECK (Mark >= 1 AND Mark <= 10),
	CONSTRAINT FK_ExamResultStudent FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID)
);
GO

CREATE TABLE ExamSets
(
	ExamSetID INT PRIMARY KEY IDENTITY(1, 1),
	ExamID INT NOT NULL,
	ExamDate DATE,
	ExamResultID INT
);
GO


-- All sessions.
CREATE TABLE UniversitySessions
(
	UniversitySessionsID INT PRIMARY KEY IDENTITY(1, 1),
	GroupID INT NOT NULL,
	AssessmentSetID INT,
	ExamSetID INT,

	CONSTRAINT FK_UniversitySessionGroup FOREIGN KEY (GroupID)
	REFERENCES Groups(GroupID),
	CONSTRAINT FK_UniversitySessionAssessmentSet FOREIGN KEY (AssessmentSetID)
	REFERENCES AssessmentSets(AssessmentSetID),
	CONSTRAINT FK_UniversitySessionsExamSet FOREIGN KEY (ExamSetID)
	REFERENCES ExamSets(ExamSetID)
);
GO