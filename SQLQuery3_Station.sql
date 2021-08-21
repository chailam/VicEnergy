BULK
INSERT Station
FROM 'C:\Users\mac\Downloads\Station.csv'
WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO