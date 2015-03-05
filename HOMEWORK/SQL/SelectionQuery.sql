---- 1. �������� �������� ���������, ������� ���������� �� ������������� 'BHV',
---- � ����� ������� >= 3000 �����������.

--use [BooksForNet14-2]
--go

--select Books.Name
--from Books, Press
--where Books.IdPress = Press.Id 
--and Press.Name not like 'BHV%' 
--and Books.Pressrun >= 3000 

---- Answer 503

---- 2. �������� ��� �����-�������, ���� ������� ���� 30�.

--select Books.Name, Price
--from Books
--where Books.New = 1 
--and Books.Price < 30 

---- Answer 18

---- 3. �������� ��� �����, � ������� � ����� ����� ������� ����.

--select Books.Name
--from Books
--where Books.Name like '% % % % %' 

---- Answer 549

---- 4. �������� �����, � ��������� ������� ���� ����� Microsoft, �� ��� ����� Windows

--select Books.Name
--from Books
--where Books.Name like '%Microsoft%' and Books.Name not like '%Windows%' 

---- Answer 26

---- 5.�������� �����, � ������� ���� ����� �������� ������ 10 ������.

--select Books.Name, Books.Pages, Books.Price
--from Books
--where Books.Pages !=0 and Books.Price/Books.Pages < 0.1 

---- Answer 567

---- 6. �������� ����� � ���� � �.�. ��� ���� ���� �������.

--select Books.Name,Books.New, Books.Price/60 as 'USD Price'
--from Books
--where Books.New =1 


---- 7. �������� ��� �����, ��� ������� � ������� 2000, � ���� >30.

--select Books.Name, YEAR(Books.Date) as 'Year'
--from Books
--where year(Books.Date) = 2000 and Books.Price >30 

---- Answer 100


---- 8. �������� ��� ������������, ������� ������ ������� � ����� >40�.

--select Press.Name
--from Press, Books
--where Press.Id = Books.IdPress and Books.New = 1 and Books.Price >40

---- 9. �������� ��� ��������, � ������� �� ������� ���������, ��� ���� �� ���������� ��������� ����������.

--select  Theme.Name
--from  Theme 
--where Theme.Id in 
--(select  Theme.Id
--from  Theme, Books 
--where Books.IdCategory is null and Books.IdTheme = Theme.Id and Theme.Id = Books.IdTheme)

---- Answer 12

---- 10. �������� �������� ���������, ������� ���������� ������������� 'BHV',
---- � ������ ����� �������� ��������� � ��������� �� � �� �.

--select Books.Name
--from Books, Category, Press, Theme
--where Books.IdCategory = Category.Id
--and Category.Name = '��������' 
--and Books.IdPress = Press.Id 
--and Press.Name like '%BHV%' 
--and Books.IdTheme = Theme.Id
--and Theme.Name like '[�-�]%'


---- Answer 4


---- 11. �������� �������� ���������, � �������� ����������� ������� ����� 3 ����.

--select Books.Name, Press.Name
--from Books, Category, Press
--where Books.IdCategory = Category.Id
--and Category.Name = '��������' 
--and Books.IdPress = Press.Id
--and Press.Name like '% % % %' 
	
---- Answer 0

---- 12.�������� �������� ���������, � �������� ����������� ������� ����� 3 �����.

--select Books.Name
--from Books, Category, Press
--where Books.IdCategory = Category.Id
--and Category.Name = '��������' 
--and Books.IdPress = Press.Id
--and Press.Name like '% % %' 


---- Answer 6
  