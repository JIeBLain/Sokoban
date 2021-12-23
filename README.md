# Sokoban

Sokoban - двухмерная компьютерная игра-головоломка, в которой игроку необходимо расставить ящики по обозначенным местам склада.

 ## Игровые объекты 
|Обозначение | Описание |
| :---: | --- |
| ♀ | игрок |
| ≡ | ящик |
| × | место для ящика |
| · | пол |
| ▓ | стена |

 ## Правила игры
 Игра проходит на двумерном поле с видом сверху. Игровое поле разделено на клетки. В одной клетке может быть стена,
 ящик или игрок. Также клетка может быть местом для ящика. Игрок может двигаться влево, вправо, вверх и вниз.
 Но не может проходить сквозь стены и ящики. Игрок может толкнуть ящик если он не упирается в стену или другой ящик. 
 Игрок побеждает если все ящики оказываются на местах для ящиков.

 ## Структура меню
 Вне зависимости от выбранного меню, каждое меню сопровождается подсказками о возможных действиях играющего.
 После запуска игры в консоли отображается главное меню, в котором можно выбрать: 'Play', 'About', 'Exit'.
 Выбор нужного пункта меню осуществляется нажатием стрелок: 'UpArrow' или DownArrow', а переход в выбранное меню происходит при нажатии клавиши 'Enter'.
 При выборе 'Play' - происходит переход в меню с выбором уровней или же возможность вернуться в главное меню нажав на 'Back'.
 При выборе 'About' - в открывшемся окне содержится краткая информации о игре и её правилах, которая была взята с Wiki.
 Для того чтобы вернуться в главное меню достаточно нажать любую клавишу.
 При выборе 'Exit' - происходит выход из программы. При это перед тем, как окончательно закрыть программу, необходимо нажать любую клавишу.
 
  ## Управление
  
  После выбора уровня происходит загрузка уровня со всеми вспомогательными подсказками о возможных действиях играющего.
  Управление персонажем происходит путём нажатия клавиш 'UpArrow', DownArrow', 'RightArrow', 'LeftArrow'.
  Также имеется возможность перезагрузить уровень - нажав клавишу 'R' или вернуться назад - нажав клавишу 'B', чтобы поменять уровень сложности.
  
  ## Условия победы
  
  После попадания ящика на отведённое ему место он меняет цвет с жёлтого на зелёный, сигнализирую, что игрок делает всё правильно.
  Как только все ящики окажутся на своих местах, они все будут иметь зелёный свет, что означает о пройденном уровне. В этот же момент всплывёт надпись о победе.
  Далее после нажатия любой клавиши игрок попадает в меню выбора уровней.
