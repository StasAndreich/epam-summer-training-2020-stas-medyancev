USE UniversityDB;
GO

INSERT INTO Groups
VALUES
('ITI-11'),
('ITI-21'),
('ITI-31'),
('ITI-41');
GO

INSERT INTO Subjects
VALUES
('Neural Networks'),
('OOP'),
('Computer Graphics'),
('Сomputer Networks');
GO

INSERT INTO Students
VALUES
('Яровой', 'Святослав', 'Романович', 'Муж', '2000-12-14', 1),
('Борисенко', 'Яромир ', 'Владимирович', 'Муж', '2000-10-03', 2),
('Желиба', 'Абрам', 'Дмитриевич', 'Муж', '2000-12-05', 1),
('Селиверстов', 'Юлий', 'Викторович', 'Муж', '1997-11-03', 1),
('Выговский', 'Устин', 'Богданович', 'Муж', '1999-12-06', 4),
('Воробьёв', 'Шерлок', 'Васильевич', 'Муж', '1999-12-29', 3),
('Якушев', 'Болеслав', 'Анатолиевич', 'Муж', '1998-06-11', 2),
('Каськив', 'Эдуард', 'Борисович', 'Муж', '1999-02-18', 2),
('Яценюк', 'Болеслав', 'Петрович', 'Муж', '2001-01-24', 3),
('Зуев', 'Чарльз', 'Петрович', 'Муж', '2000-09-10', 4);
GO

INSERT INTO Exams
VALUES
(1, '2020-01-19', 2, 8),
(2, '2020-01-14', 2, 2),
(1, '2020-06-11', 3, 9),
(2, '2020-06-18', 4, 8),
(3, '2020-06-17', 6, 7),
(4, '2020-06-11', 6, 5),
(4, '2020-06-12', 7, 3),
(2, '2020-06-11', 8, 4);
GO

INSERT INTO Assessments
VALUES
(1, '2020-01-19', 1, 'зач'),
(2, '2020-01-14', 2, 'незач'),
(1, '2020-06-11', 3, 'незач'),
(2, '2020-06-18', 4, 'зач'),
(3, '2020-06-17', 9, 'зач'),
(4, '2020-06-11', 6, 'незач'),
(2, '2020-06-11', 8, 'зач');
GO