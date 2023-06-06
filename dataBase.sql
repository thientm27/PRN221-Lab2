CREATE DATABASE MySchool;

USE MySchool;

-- Create the Course table
CREATE TABLE Course (
  CourseID INT PRIMARY KEY,
  Title VARCHAR(255),
  Credits INT
);

-- Create the Enrollment table
CREATE TABLE Enrollment (
  EnrollmentID INT PRIMARY KEY,
  CourseID INT,
  StudentID INT,
  Grade INT,
  FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
  FOREIGN KEY (StudentID) REFERENCES Student(ID)
);

-- Create the Student table
CREATE TABLE Student (
  ID INT IDENTITY(1,1) PRIMARY KEY,
  LastName VARCHAR(255),
  FirstMidName VARCHAR(255),
  EnrollmentDate DATE
);

-- Insert sample data into the Course table
INSERT INTO Course (CourseID, Title, Credits)
VALUES
  (1, 'Mathematics', 3),
  (2, 'English Literature', 4),
  (3, 'Computer Science', 5),
  (4, 'History', 3),
  (5, 'Physics', 4),
  (6, 'Chemistry', 4),
  (7, 'Art', 2),
  (8, 'Biology', 3),
  (9, 'Psychology', 4),
  (10, 'Economics', 3);

-- Insert sample data into the Student table
INSERT INTO Student (LastName, FirstMidName, EnrollmentDate)
VALUES
  ('Smith', 'John', '2021-09-01'),
  ('Johnson', 'Emily', '2021-09-02'),
  ('Williams', 'Michael', '2021-09-03'),
  ('Jones', 'Jessica', '2021-09-04'),
  ('Brown', 'David', '2021-09-05'),
  ('Davis', 'Sarah', '2021-09-06'),
  ('Miller', 'Robert', '2021-09-07'),
  ('Wilson', 'Jennifer', '2021-09-08'),
  ('Moore', 'Daniel', '2021-09-09'),
  ('Taylor', 'Lisa', '2021-09-10');

-- Insert sample data into the Enrollment table
INSERT INTO Enrollment (EnrollmentID, CourseID, StudentID, Grade)
VALUES
  (1, 1, 1, 85),
  (2, 2, 1, 92),
  (3, 3, 1, 78),
  (4, 4, 1, 88),
  (5, 5, 1, 95),
  (6, 1, 2, 90),
  (7, 3, 2, 82),
  (8, 6, 2, 76),
  (9, 8, 2, 87),
  (10, 10, 2, 91);
