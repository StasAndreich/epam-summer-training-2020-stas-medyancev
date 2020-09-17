CREATE DATABASE UniversityDBExtended;
GO

USE  UniversityDBExtended;
GO

CREATE TABLE Specialty
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	SpecialtyName NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Group]
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	GroupName NVARCHAR(10) NOT NULL,
	SpecialtyId INT,

	CONSTRAINT FK_GroupSpecialty FOREIGN KEY (SpecialtyId)
	REFERENCES Specialty(Id)
);
GO

CREATE TABLE Examiner
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(50) NOT NULL,
	Surname NVARCHAR(50) NOT NULL,
	Patronym NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Student
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(50) NOT NULL,
	Surname NVARCHAR(50) NOT NULL,
	Patronym NVARCHAR(50) NOT NULL,
	Sex NVARCHAR(10) NOT NULL,
	BirthDate DATE NOT NULL,
	GroupId INT,

	CONSTRAINT FK_StudentGroup FOREIGN KEY (GroupId)
	REFERENCES [Group](Id)
);
GO

CREATE TABLE [Subject]
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	SubjectName NVARCHAR(70) NOT NULL
);
GO

CREATE TABLE Assessment
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	SubjectId INT,
	AssessmentDate DATE,
	StudentId INT,
	Result NVARCHAR(10),
	ExaminerId INT,

	CONSTRAINT FK_AssessmentStudent FOREIGN KEY (StudentId)
	REFERENCES Student(Id),
	CONSTRAINT FK_AssessmentSubject FOREIGN KEY (SubjectId)
	REFERENCES [Subject](Id),
	CONSTRAINT FK_AssessmentExaminer FOREIGN KEY (ExaminerId)
	REFERENCES Examiner(Id)
);
GO

CREATE TABLE Exam
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	SubjectId INT,
	ExamDate DATE,
	StudentId INT,
	Mark INT,
	ExaminerId INT,

	CONSTRAINT CHK_Mark CHECK (Mark >= 1 AND Mark <= 10),

	CONSTRAINT FK_ExamStudent FOREIGN KEY (StudentId)
	REFERENCES Student(Id),
	CONSTRAINT FK_ExamSubject FOREIGN KEY (SubjectId)
	REFERENCES [Subject](Id),
	CONSTRAINT FK_ExamExaminer FOREIGN KEY (ExaminerId)
	REFERENCES Examiner(Id)
);
GO