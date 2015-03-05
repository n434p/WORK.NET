--Вывести статистику посещений библиотеки по каждой группе студентов. 

--select Groups.Name, count(Students.Id)
--from Groups, S_Cards, Students
--where 
--Groups.Id = Students.Id_Group
--and Students.Id = S_Cards.Id_Student
--group by Groups.Name

--Вывести количество книг, взятых в библиотеке программистами по тематикам "Программирование" и "Базы данных", и сумму страниц в этих книгах. 

--select count(Books.Id), sum(Books.Pages)
--from Books, Faculties, Groups, Students, S_Cards, Themes
--where Faculties.Name = 'Программирования'
--and Faculties.Id = Groups.Id_Faculty
--and Groups.Id = Students.Id_Group
--and S_Cards.Id_Student = Students.Id
--and S_Cards.Id_Book = Books.Id
--and Themes.Name in ('Программирование','Базы данных')


--Вывести информацию о книге с наибольшим количеством страниц. 

--select Books.Name, Books.Pages
--from Books
--where Books.Pages = (select max(Pages) from Books)

--Вывести информацию о книге по программированию с наибольшим количеством страниц. 

--select Books.Name, Books.Pages
--from Books
--where Books.Pages = (select max(Pages) from Books, Themes where Themes.Id = Books.Id_Themes and Themes.Name = 'Программирование')

--Допустим, что студент имеет право держать книгу у себя дома только 1 месяц, 
--а за каждую неделю сверх того он обязан "выставить" уважаемому библиотекарю 
--Максу (Сергею Максименко) полбутылки (емкость бутылки 0.5 л) светлого пива.
--Необходимо вывести сколько литров должен каждый студент, а также суммарное 
--количество литров пива. Итоговая сумма должна округляться в большую сторону, 
--то есть суммарное число литров должно быть целым. (Для округления можно использовать функцию). 

--select Students.FirstName, Students.LastName, (S_Cards.DateIn - S_Cards.DateOut)
--from Students, S_Cards, Libs, Books
--where Students.Id = S_Cards.Id_Student
--and S_Cards.Id_Lib = Libs.Id
--and Books.Id = S_Cards.Id_Book
--and Libs.Id =1
--and (Days(S_Cards.DateIn) - S_Cards.DateOut) > 
----group by Students.FirstName, Students.LastName

--Если считать общее количество книг в библиотеке за 100%, то необходимо подсчитать сколько книг (в процентном отношении) брал каждый факультет. 

--select Faculties.Name, count(Books.id)*100/(select count(*) from Books)
--from Faculties,Groups,Students,S_Cards,Books 
--where Faculties.Id = Groups.Id_Faculty
--and Groups.Id = Students.Id_Group
--and S_Cards.Id_Student = Students.Id
--and S_Cards.Id_Book = Books.Id 
--GROUP BY Faculties.Name

--Вывести самого популярного автора(ов) среди студентов. 

--select Authors.FirstName, Authors.LastName
--from Authors,
--(
--select Authors.Id as a, count(Id_Author) as c
--from Authors, S_Cards, Books 
--where Authors.Id = Books.Id_Author
--and Books.Id = S_Cards.Id_Book
--group by Authors.Id
--) as Temp
--where Temp.c = 
--(
--		select max(Temp2.c) from 
--		(
--		select Authors.Id , count(Id_Author) as c 
--		from Authors, S_Cards, Books 
--		where Authors.Id = Books.Id_Author
--		and Books.Id = S_Cards.Id_Book
--		group by Authors.Id
--		) as Temp2)
--and Temp.a = Authors.Id

--Вывести самого популярного автора(ов) среди преподавателей и количество книг этого автора, взятых в библиотеке. 

--select Authors.FirstName, Authors.LastName, count(Books.Id)
--from Authors, Books,
--(
--select Authors.Id as a, count(Id_Author) as c
--from Authors, S_Cards, Books 
--where Authors.Id = Books.Id_Author
--and Books.Id = S_Cards.Id_Book
--group by Authors.Id
--) as Temp
--where Temp.c = 
--(
--		select max(Temp2.c) from 
--		(
--		select Authors.Id , count(Id_Author) as c 
--		from Authors, T_Cards, Books 
--		where Authors.Id = Books.Id_Author
--		and Books.Id = T_Cards.Id_Book
--		group by Authors.Id
--		) as Temp2)
--and Temp.a = Authors.Id
--and Temp.a = Books.Id_Author
--and Authors.Id = Books.Id_Author
--group by Authors.FirstName, Authors.LastName


--Вывести самого популярную(ые) тематику(и) среди студентов и преподавателей. 


--select Themes.Name
--from Themes,
--(
--select Themes.Id as themeID, count(Id_Themes) as countThemes
--from Themes, S_Cards, T_Cards, Books 
--where Themes.Id = Books.Id_Themes
--and Books.Id = S_Cards.Id_Book
--and Books.Id = T_Cards.Id_Book
--group by Themes.Id
--) as Temp
--where Temp.countThemes = 
--(
--		select max(Temp2.countThemes) from 
--		(
--		select Themes.Id, count(Id_Themes) as countThemes
--		from Themes, S_Cards, T_Cards, Books 
--		where Themes.Id = Books.Id_Themes
--		and Books.Id = S_Cards.Id_Book
--		and Books.Id = T_Cards.Id_Book
--		group by Themes.Id
--		) as Temp2)
--and Temp.themeID = Themes.Id
