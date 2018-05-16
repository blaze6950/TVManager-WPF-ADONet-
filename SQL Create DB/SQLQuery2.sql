INSERT INTO TVSeriesTable--(Name, Image, YearOfIssue, Seasons, Desription)
VALUES ('Lie to me', 'C:\', 2009, 3, 'Доктор Кэл Лайтман — самый лучший в мире специалист по определению лжи и эмоций. Ему надо всего несколько минут, чтобы понять твои мотивы и намерения, обратив внимание на мимику лица, язык телодвижения, на твой голос и содержание речи. Имея такие знания он, и его команда, работающая на его же компанию «The Lightman Group», спасают множество судеб, предотвращая преступления, наказывая виновных и оправдывая ни в чём неповинных людей.', 1)

SELECT *
FROM TVSeriesTable

INSERT INTO Channels
Values ('CBS')

SELECT *
FROM Channels

SELECT TVSeriesTable.Id, TVSeriesTable.Image, TVSeriesTable.Name, TVSeriesTable.YearOfIssue 
FROM TVSeriesTable JOIN Channels ON TVSeriesTable.Channel_Id = Channels.Id 
LEFT JOIN TVSeriesGenres ON TVSeriesTable.Id = TVSeriesGenres.TVSeries_Id 
LEFT JOIN Genres ON Genres.Id = TVSeriesGenres.Genre_Id 
WHERE Channels.Name IN ('FOX')

INSERT INTO TVSeriesTable
VALUES ('The Big Bang Theory', 'E:\GoogleDrive\Программовня\ADONet\Examples\TVManager(WPF, ADONet)\TVManager(WPF, ADONet)\Pictures\TBBT.jpg', 2007, 12, 'Леонард, Шелдон, Говард и Раджеш молодые гениальные ученые, помимо работы они увлекаются комиксами, видеоиграми, фантастикой, эпическими сагами, наукой, техникой и т.п. Их привычный ритм жизни меняется тогда, когда напротив Леонарда и Шелдона поселяется симпатичная блондинка Пенни, в которую сразу же влюбляется Леонард. Юмор заключается в отличии героев от остальных людей, с чем и столкнется их новая соседка.', 12)

SELECT TVSeriesTable.Id, TVSeriesTable.Image, TVSeriesTable.Name, TVSeriesTable.YearOfIssue FROM TVSeriesTable JOIN Channels ON TVSeriesTable.Channel_Id = Channels.Id LEFT JOIN TVSeriesGenres ON TVSeriesTable.Id = TVSeriesGenres.TVSeries_Id LEFT JOIN Genres ON Genres.Id = TVSeriesGenres.Genre_Id 

SELECT Id, Image, TVSeriesTable.Name, YearOfIssue 
FROM TVSeriesTable 
WHERE Name LIKE '%Game%'