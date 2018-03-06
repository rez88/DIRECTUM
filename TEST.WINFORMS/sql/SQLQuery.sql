Select e.Surname, e.Name, SUM(s.Quantity) as kol_prod
From dbo.Sellers As e Join dbo.Sales As s
ON s.IDSel=e.Id
Where s.Date between '2013/10/01' and '2013/10/07' 
Group by e.Surname, e.Name
Order by e.Surname