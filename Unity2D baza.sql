CREATE DATABASE Unity2D;


USE Unity2D;


CREATE TABLE Users(
    UserID INT PRIMARY KEY auto_increment,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Win_count INT DEFAULT 0,
    Lose_count INT DEFAULT 0
);

select *from Users;
