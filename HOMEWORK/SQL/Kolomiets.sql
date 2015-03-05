--������� ���������� ��������� ���������� �� ������ ������ ���������. 

--select Groups.Name, count(Students.Id)
--from Groups, S_Cards, Students
--where 
--Groups.Id = Students.Id_Group
--and Students.Id = S_Cards.Id_Student
--group by Groups.Name

--������� ���������� ����, ������ � ���������� �������������� �� ��������� "����������������" � "���� ������", � ����� ������� � ���� ������. 

--select count(Books.Id), sum(Books.Pages)
--from Books, Faculties, Groups, Students, S_Cards, Themes
--where Faculties.Name = '����������������'
--and Faculties.Id = Groups.Id_Faculty
--and Groups.Id = Students.Id_Group
--and S_Cards.Id_Student = Students.Id
--and S_Cards.Id_Book = Books.Id
--and Themes.Name in ('����������������','���� ������')


--������� ���������� � ����� � ���������� ����������� �������. 

--select Books.Name, Books.Pages
--from Books
--where Books.Pages = (select max(Pages) from Books)

--������� ���������� � ����� �� ���������������� � ���������� ����������� �������. 

--select Books.Name, Books.Pages
--from Books
--where Books.Pages = (select max(Pages) from Books, Themes where Themes.Id = Books.Id_Themes and Themes.Name = '����������������')

--��������, ��� ������� ����� ����� ������� ����� � ���� ���� ������ 1 �����, 
--� �� ������ ������ ����� ���� �� ������ "���������" ���������� ������������ 
--����� (������ ����������) ���������� (������� ������� 0.5 �) �������� ����.
--���������� ������� ������� ������ ������ ������ �������, � ����� ��������� 
--���������� ������ ����. �������� ����� ������ ����������� � ������� �������, 
--�� ���� ��������� ����� ������ ������ ���� �����. (��� ���������� ����� ������������ �������). 

--select Students.FirstName, Students.LastName, (S_Cards.DateIn - S_Cards.DateOut)
--from Students, S_Cards, Libs, Books
--where Students.Id = S_Cards.Id_Student
--and S_Cards.Id_Lib = Libs.Id
--and Books.Id = S_Cards.Id_Book
--and Libs.Id =1
--and (Days(S_Cards.DateIn) - S_Cards.DateOut) > 
----group by Students.FirstName, Students.LastName

--���� ������� ����� ���������� ���� � ���������� �� 100%, �� ���������� ���������� ������� ���� (� ���������� ���������) ���� ������ ���������. 

--select Faculties.Name, count(Books.id)*100/(select count(*) from Books)
--from Faculties,Groups,Students,S_Cards,Books 
--where Faculties.Id = Groups.Id_Faculty
--and Groups.Id = Students.Id_Group
--and S_Cards.Id_Student = Students.Id
--and S_Cards.Id_Book = Books.Id 
--GROUP BY Faculties.Name

--������� ������ ����������� ������(��) ����� ���������. 

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

--������� ������ ����������� ������(��) ����� �������������� � ���������� ���� ����� ������, ������ � ����������. 

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


--������� ������ ����������(��) ��������(�) ����� ��������� � ��������������. 


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
