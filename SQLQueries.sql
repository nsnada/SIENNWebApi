--Unavailable products which delivery is expected in current month

select * from Products where month(DelivaryDate) = month(GETDATE()) and IsAvailable = 0

--Available products that are assigned to more than one category

select p.id as ProductId, p.Description from products p
join ProductCategories pc on p.Id = pc.ProductId
where p.IsAvailable = 1
group by p.id, p.Description
having count(pc.CategoryId) > 1

--Top 3 categories with info about numbers of available, assigned products with its mean price
--in category (top 3 should display categories which mean price is the highest)

select top 3 c.id as CategoryId, c.Description, count(pc.ProductId) as NumberOfProducts, sum(p.Price)/count(pc.ProductId) as MeanPrice from Categories c
join ProductCategories pc on c.Id = pc.CategoryId
join Products p on pc.ProductId = p.Id
where p.IsAvailable = 1
group by c.id, c.Description
order by MeanPrice desc