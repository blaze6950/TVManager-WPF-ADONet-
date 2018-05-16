INSERT INTO TVSeriesTable--(Name, Image, YearOfIssue, Seasons, Desription)
VALUES ('Lie to me', 'C:\', 2009, 3, '������ ��� ������� � ����� ������ � ���� ���������� �� ����������� ��� � ������. ��� ���� ����� ��������� �����, ����� ������ ���� ������ � ���������, ������� �������� �� ������ ����, ���� ������������, �� ���� ����� � ���������� ����. ���� ����� ������ ��, � ��� �������, ���������� �� ��� �� �������� �The Lightman Group�, ������� ��������� �����, ������������ ������������, ��������� �������� � ���������� �� � ��� ���������� �����.', 1)

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
VALUES ('The Big Bang Theory', 'E:\GoogleDrive\������������\ADONet\Examples\TVManager(WPF, ADONet)\TVManager(WPF, ADONet)\Pictures\TBBT.jpg', 2007, 12, '�������, ������, ������ � ������ ������� ���������� ������, ������ ������ ��� ���������� ���������, �����������, �����������, ���������� ������, ������, �������� � �.�. �� ��������� ���� ����� �������� �����, ����� �������� �������� � ������� ���������� ����������� ��������� �����, � ������� ����� �� ���������� �������. ���� ����������� � ������� ������ �� ��������� �����, � ��� � ���������� �� ����� �������.', 12)

SELECT TVSeriesTable.Id, TVSeriesTable.Image, TVSeriesTable.Name, TVSeriesTable.YearOfIssue FROM TVSeriesTable JOIN Channels ON TVSeriesTable.Channel_Id = Channels.Id LEFT JOIN TVSeriesGenres ON TVSeriesTable.Id = TVSeriesGenres.TVSeries_Id LEFT JOIN Genres ON Genres.Id = TVSeriesGenres.Genre_Id 

SELECT Id, Image, TVSeriesTable.Name, YearOfIssue 
FROM TVSeriesTable 
WHERE Name LIKE '%Game%'