Select p.Name as prod, e.Surname, e.Name, SUM(s.Quantity) as kol_prod, sum(a.Quantity) as obsh_kol,  SUM(s.Quantity)/(Select sum(s.Quantity) From dbo.Sales as s JOIN dbo.Products as p ON s.IDProd=p.Id WHERE s.Date between '2013/10/01' and '2013/10/07' and p.Name=)*100 as procent
From dbo.Sales As s 
Join dbo.Sellers As e ON s.IDSel=e.Id
Join dbo.Products As p ON s.IDProd=p.Id
Join dbo.Arrivals As a ON a.IDProd=p.Id
Where s.Date between '2013/10/01' and '2013/10/07' and a.Date between '2013/09/07' and '2013/10/07' 
Group by p.Name, e.Surname, e.Name
Order by e.Surname