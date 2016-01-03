INSERT INTO Films.dbo.Films (Id, Picture, Name, Country, Year, Producer) 
SELECT 1, BulkColumn, '������� ����', '���', '1999', '����� ��������'
FROM Openrowset( Bulk 'C:\Users\GOD\Desktop\PicturesForFilms\GreenMile.jpg', Single_Blob) AS image

insert into Actor (Id, Name) values (1, '��� �����')
insert into Actor (Id, Name) values (2, '����� ����')
insert into Actor (Id, Name) values (3, '����� ����� ������')

insert into ActorToFilm (Id, ActorId, FilmId) values (1, 1, 1)
insert into ActorToFilm (Id, ActorId, FilmId) values (2, 2, 1)
insert into ActorToFilm (Id, ActorId, FilmId) values (3, 3, 1)


INSERT INTO Films.dbo.Films (Id, Picture, Name, Country, Year, Producer) 
SELECT 2, BulkColumn, '������ ��������', '���', '1993', '������ ��������'
FROM Openrowset( Bulk 'C:\Users\GOD\Desktop\PicturesForFilms\ShindlerList.jpg', Single_Blob) AS image

insert into Actor (Id, Name) values (4, '���� �����')
insert into Actor (Id, Name) values (5, '��� �������')
insert into Actor (Id, Name) values (6, '���� �����')

insert into ActorToFilm (Id, ActorId, FilmId) values (4, 4, 2)
insert into ActorToFilm (Id, ActorId, FilmId) values (5, 5, 2)
insert into ActorToFilm (Id, ActorId, FilmId) values (6, 6, 2)


