   M S B A M L   `   `   `  ����G  CConnectTable, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ConnectTable.ViewConnectTable.View  5   	   ?$clr-namespace:ConnectTable.ViewModelConnectTable.ViewModel  5   	   "    ConnectTable.View.ViewTables   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   1localclr-namespace:ConnectTable.View     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3vm$clr-namespace:ConnectTable.ViewModel     5   	   -   5          � Title$  
ViewTables��5   	   $��Stretch=�5	   	   $��Stretch=�5
   	    � WindowState$ 	Maximized=�5   	    � 	Resources 5      ,  &ConnectTable.ViewModel.ViewModelTables   ViewModelTables��%   &	          5   
   6   5      .��5      � .+�5   
   �� -   5         ��Name$ 
tabControl��5      $��4��5      $��3,3,2,25q�5      �� 5   
   -   5         ��Name$ 	btnFilter��5      $��47��5      $��73,0,0,0q�5      $
��Left=�5      $��Bottom=�5      $��
Set filter��5       J� RenderTransformOrigin$ 
-0.227,0.5&�5      ��5      �� *SetFilterUserCommand+5      �� 5   
   -   5        $ btnClose��5      $��57��5      $��Right=�5       $��Bottom=�5!      $��Close��5#      ��5"      �� *CloseUserCommand+5#      �� 5$   
   -   5        $ btnXLS��5$      $��45��5%      $��	188,0,0,0q�5&      $
��Left=�5'      $��Bottom=�5(      $	��XLS��5*      ��5)      �� *Export2XLSUserCommand+5*      �� 5+   
   -   5        $ 	btnDelete��5+      $��61��5,      $��7,0,0,0q�5-      $
��Left=�5.      $��Bottom=�5/      $��Close table��51      ��50      �� *CloseTableUserCommand+51      �� 52   
   -   5        $ btnOpenTable��52      $��67��53      $��	338,0,0,0q�54      $
��Left=�55      $��Bottom=�56      $��Open new��58      ��57      �� *OpenTableUserCommand+58      �� 59   
   -   5        $ btnClearFilter��59      $��59��5:      $��	125,0,0,1q�5;      $
��Left=�5<      $��Bottom=�5=      $��Clear filter��5?      ��5>      �� *ClearFilterUserCommand+5?      �� 5@   
   -	   5        $ btnPDF��5@      $��45��5A      $��	238,0,0,0q�5B      $
��Left=�5C      $��Bottom=�5D      $	��PDF��5F      $ 1.6,0.55&�5G      ��5E      �� *Export2PDFUserCommand+5G      �� 5H   
   -
   5        $ btnCSV��5H      $��45��5I      $��	288,0,0,0q�5J      $
��Left=�5K      $��Bottom=�5L      $	��CSV��5N      $ 1.6,0.55&�5O      ��5M      �� *Export2CSVUserCommand+5O      5Q      5R      