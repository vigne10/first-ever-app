   M S B A M L   `   `   `  ����D  @WpfBVimmo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfBVimmo	WpfBVimmo  5   	        WpfBVimmo.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfBVimmo     5   	     � Title$  Gestion immobilière��5   	   $	��630��6%   $
��1399��62    � WindowStartupLocation$ CenterScreen=�6?    � WindowState$ 	Maximized=�5	   	    � Icon$ 	icon1.ico��5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� $	��Top=�6   $��0��6$   .@�5      m� $��
_Programme��6   .@�5      m� -   5        $��_Sauvegarder��5      61   �� 5      m� 5      -   5        $��_Quitter��5      6-   5      m� 5      $��
_Bâtiment��6   .@�5      m� -   5        $��_Nouveau bâtiment��5      66   5      5      �� 5    
   $��Maisons��6   $��Center=�6"   $��1��6G   � 5"   
   $��
20 0 20 10q�6   $��2��6#   .+�5%      &   System.Windows.Controls.DataGrid  -   5        $��DataGridHouse��5%         AutoGenerateColumns .  ��. 
�������$
��Auto=�5(      $
��Auto=�6C      CanUserAddRows .  $��Center=�5)   *      SelectionUnit$ FullRow=�6G      CanUserDeleteRows .  $
��Auto��5*      	   AlternatingRowBackground
	 �����
�������
   VerticalGridLinesBrush

 �����   HorizontalGridLinesBrush
 �����$��Center=�5+   <   ��5%   ,   �� *HouseListView+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5&      �� *SelBuilding+$ TwoWay=�   Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$ Statut��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ��  �� Path$ ActualStatus�  5.      $ Identifiant��6)    6>   �� $ 
BuildingID�  5/      $
 Pays��6)      MaxWidth$	 150Q�6Z    67   �� $ Country�6Z     50      $ Ville��6)   $	 150Q�6X    68   �� $
 City�6X     51      $ Adresse��6)   $	 260Q�6]    6:   �� $ Address�6]     52      $	 N°��6)    65   �� $ AddressNumber�  53      $ 
Superficie��6)   $	 100Q�6]    6=   �� $
 Area�6]     54      $ Superficie du terrain��6)   $	 150Q�6l    6H   �� $ LandArea�6l     55      $ Nombre d'étages��6)   $	 105Q�6k    6B   �� $ NumberOfFloor�6k     56      $ Pièces��6)   $	 100Q�6b    69   �� $ NumberOfRooms�6b     57      $ Chambres��6)   $	 100Q�6g    6;   �� $ NumberOfBedrooms�6g     58      $ Salles de bain��6)   $	 100Q�6n    6A   �� $ NumberOfBathrooms�6n     59      $ WC��6)   $	 100Q�6[    65   �� $ 
NumberOfWC�6[   4  .System.Windows.Controls.DataGridCheckBoxColumn  5:      $
 Cave��6-    6;   �� $ Cellar�  5;      $ Grenier��6-    6>   �� $ Attic�  5<      $ Jardin privé��6-    6C   �� $ PrivateGarden�  5=      $ Terrasse privée��6-    6F   �� $ PrivateTerrace�  5>      $ Piscine publique��6-    6G   �� $ 
SharedPool�  5?      $ Piscine privée��6-    6E   �� $ PrivatePool�  5@      $ Parking intérieur��6)   $	 150Q�6m    6D   �� $ IndoorParking�6m     5A      $ Parking extérieur��6)   $	 150Q�6n    6D   �� $ OutdoorParking�6n   5C      5D      �� 5F   
   $��Appartemments��6   $��Center=�6(   $��3��6L   � 5H   
   $��4��6   $��
20 0 20 15q�6   .+�5I        -   5        $��DataGridApartment��5I       .  ��. 
�������$
��Auto=�5L      $
��Auto=�6C    .  $��Center=�5M   *   $ FullRow=�6G    .  $
��Auto��5N      
	 �����
�������

 �����
 �������5I   0   �� *ApartListView+$ TwoWay=�$ PropertyChanged=� 5J      �� *SelBuilding+$ TwoWay=� 5P        5Q      $ Statut��6)    69   �� $ ActualStatus�  5R      $ Identifiant��6)    6>   �� $ 
BuildingID�  5S      $
 Pays��6)   $	 150Q�6Z    67   �� $ Country�6Z     5T      $ Ville��6)   $	 150Q�6X    68   �� $
 City�6X     5U      $ Adresse��6)   $	 260Q�6]    6:   �� $ Address�6]     5V      $	 N°��6)    65   �� $ AddressNumber�  5W      $ Etage��6)   $	 100Q�6Y    68   �� $ Floor�6Y     5X      $ 	Ascenceur��6-    6@   �� $ Elevator�  5Y      $ 
Superficie��6)   $	 100Q�6]    6=   �� $
 Area�6]     5Z      $ Pièces��6)   $	 100Q�6b    69   �� $ NumberOfRooms�6b     5[      $ Chambres��6)   $	 100Q�6g    6;   �� $ NumberOfBedrooms�6g     5\      $ Salles de bain��6)   $	 100Q�6n    6A   �� $ NumberOfBathrooms�6n     5]      $ WC��6)   $	 100Q�6[    65   �� $ 
NumberOfWC�6[     5^      $
 Cave��6-    6;   �� $ Cellar�  5_      $ Jardin privé��6-    6C   �� $ PrivateGarden�  5`      $ Jardin public��6-    6D   �� $ SharedGarden�  5a      $ Terrasse privée��6-    6F   �� $ PrivateTerrace�  5b      $ Terrasse publique��6-    6H   �� $ SharedTerrace�  5c      $ Piscine publique��6-    6G   �� $ 
SharedPool�  5d      $ Parking intérieur��6)   $	 150Q�6m    6D   �� $ IndoorParking�6m     5e      $ Parking extérieur��6)   $	 150Q�6n    6D   �� $ OutdoorParking�6n   5g      5h      5j      5k      