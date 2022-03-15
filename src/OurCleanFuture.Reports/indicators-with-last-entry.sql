SELECT
  [i].[id],
  [i].[title],
  [a].[id],
  [a].[number],
  [a].[title],
  [i].[collectioninterval],
  CONVERT(varchar(100), CONVERT(date, (SELECT TOP (1)
    [e].[enddate]
  FROM [entries] AS [e]
  WHERE [i].[id] = [e].[indicatorid]
  ORDER BY [e].[enddate] DESC)
  )) AS
  'LastEntryDate',
  CAST((SELECT TOP (1)
    [e0].[value]
  FROM [entries] AS [e0]
  WHERE [i].[id] = [e0].[indicatorid]
  ORDER BY [e0].[enddate] DESC)
  AS float) AS
  'LastEntryValue',
  CASE
    WHEN [t].[id] IS NULL THEN NULL
    ELSE [t].[value]
  END AS
  'TargetValue',
  [u].[symbol]
FROM [indicators] AS [i]
LEFT JOIN [actions] AS [a]
  ON [i].[actionid] = [a].[id]
LEFT JOIN [targets] AS [t]
  ON [i].[id] = [t].[indicatorid]
INNER JOIN [unitsofmeasurement] AS [u]
  ON [i].[unitofmeasurementid] = [u].[id]
WHERE [a].[id] IS NOT NULL

GO