---- 1. ¬ытащить название учебников, которые издавались не издательством 'BHV',
---- и тираж которых >= 3000 экземпл€ров.

--use [BooksForNet14-2]
--go

--select Books.Name
--from Books, Press
--where Books.IdPress = Press.Id 
--and Press.Name not like 'BHV%' 
--and Books.Pressrun >= 3000 

---- Answer 503

---- 2. ¬ытащить все книги-новинки, цена которых ниже 30р.

--select Books.Name, Price
--from Books
--where Books.New = 1 
--and Books.Price < 30 

---- Answer 18

---- 3. ¬ытащить все книги, у которых в имени белее четырех слов.

--select Books.Name
--from Books
--where Books.Name like '% % % % %' 

---- Answer 549

---- 4. ¬ытащить книги, в названи€х которых есть слово Microsoft, но нет слова Windows

--select Books.Name
--from Books
--where Books.Name like '%Microsoft%' and Books.Name not like '%Windows%' 

---- Answer 26

---- 5.¬ытащить книги, у которых цена одной страницы меньше 10 копеек.

--select Books.Name, Books.Pages, Books.Price
--from Books
--where Books.Pages !=0 and Books.Price/Books.Pages < 0.1 

---- Answer 567

---- 6. ¬ытащить книги и цену в у.е. дл€ всех книг новинок.

--select Books.Name,Books.New, Books.Price/60 as 'USD Price'
--from Books
--where Books.New =1 


---- 7. ¬ычитать все книги, год издани€ у которых 2000, а цена >30.

--select Books.Name, YEAR(Books.Date) as 'Year'
--from Books
--where year(Books.Date) = 2000 and Books.Price >30 

---- Answer 100


---- 8. ¬ычитать все издательства, которые издали новинки с ценой >40р.

--select Press.Name
--from Press, Books
--where Press.Id = Books.IdPress and Books.New = 1 and Books.Price >40

---- 9. ¬ычитать все тематики, у которых не указана категори€, при этом из результата исключить повторени€.

--select  Theme.Name
--from  Theme 
--where Theme.Id in 
--(select  Theme.Id
--from  Theme, Books 
--where Books.IdCategory is null and Books.IdTheme = Theme.Id and Theme.Id = Books.IdTheme)

---- Answer 12

---- 10. ¬ытащить название учебников, которые издавались издательством 'BHV',
---- а перва€ буква тематики находитс€ в диапазоне от ≈ до  .

--select Books.Name
--from Books, Category, Press, Theme
--where Books.IdCategory = Category.Id
--and Category.Name = '”чебники' 
--and Books.IdPress = Press.Id 
--and Press.Name like '%BHV%' 
--and Books.IdTheme = Theme.Id
--and Theme.Name like '[е-к]%'


---- Answer 4


---- 11. ¬ычитать название учебников, в названии издательств которых более 3 слов.

--select Books.Name, Press.Name
--from Books, Category, Press
--where Books.IdCategory = Category.Id
--and Category.Name = '”чебники' 
--and Books.IdPress = Press.Id
--and Press.Name like '% % % %' 
	
---- Answer 0

---- 12.¬ычитать название учебников, в названии издательств которых ровно 3 слова.

--select Books.Name
--from Books, Category, Press
--where Books.IdCategory = Category.Id
--and Category.Name = '”чебники' 
--and Books.IdPress = Press.Id
--and Press.Name like '% % %' 


---- Answer 6
  