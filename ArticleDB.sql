create database ArticleDB

use ArticleDB
go
CREATE TABLE Category(id INT PRIMARY KEY IDENTITY(1,1), category_name VARCHAR(255), category_description VARCHAR(255));
INSERT INTO Category VALUES('test1', 'test1');
INSERT INTO Category VALUES('test2', 'test2');
INSERT INTO Category VALUES('test3', 'test3');
INSERT INTO Category VALUES('test4','test4');

use ArticleDB
go
CREATE TABLE Article(id INT PRIMARY KEY IDENTITY(1,1), article_title VARCHAR(2000), 
article_description VARCHAR(MAX), category_id INT FOREIGN KEY REFERENCES Category(id));

select * from Category
select *   from Article 
insert into Article values
('Article1','Article1Desc',1),
('Article2','Article2Desc',1),
('Article3','Article3Desc',2),
('Article4','Article4Desc',2),
('Article5','Article5Desc',3),
('Article6','Article6Desc',3),
('Article7','Article7Desc',4),
('Article8','Article8Desc',4)
