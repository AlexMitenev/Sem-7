INSERT INTO Films.dbo.Films (Id, Picture, Name, Country, Year, Producer) 
SELECT 1, BulkColumn, 'Зеленая миля', 'США', '1999', 'Фрэнк Дарабонт'
FROM Openrowset( Bulk 'C:\Users\GOD\Desktop\PicturesForFilms\GreenMile.jpg', Single_Blob) AS image

insert into Actor (Id, Name) values (1, 'Том Хэнкс')
insert into Actor (Id, Name) values (2, 'Дэвид Морс')
insert into Actor (Id, Name) values (3, 'Майкл Кларк Дункан')

insert into ActorToFilm (Id, ActorId, FilmId) values (1, 1, 1)
insert into ActorToFilm (Id, ActorId, FilmId) values (2, 2, 1)
insert into ActorToFilm (Id, ActorId, FilmId) values (3, 3, 1)


INSERT INTO Films.dbo.Films (Id, Picture, Name, Country, Year, Producer) 
SELECT 2, BulkColumn, 'Список Шиндлера', 'США', '1993', 'Стивен Спилберг'
FROM Openrowset( Bulk 'C:\Users\GOD\Desktop\PicturesForFilms\ShindlerList.jpg', Single_Blob) AS image

insert into Actor (Id, Name) values (4, 'Лиам Нисон')
insert into Actor (Id, Name) values (5, 'Бен Кингсли')
insert into Actor (Id, Name) values (6, 'Рэйф Файнс')

insert into ActorToFilm (Id, ActorId, FilmId) values (4, 4, 2)
insert into ActorToFilm (Id, ActorId, FilmId) values (5, 5, 2)
insert into ActorToFilm (Id, ActorId, FilmId) values (6, 6, 2)


