   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewView  5   	       View.windows.SolvedWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #viewclr-namespace:View     5   	   $	��400��5   
   $	��500��6     � 	Resources  5	      ��%    5
      .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   r� -   5        $��Media��5   -    r� LoadedBehavior$
 Play=�6    r� Source$ mp3/solved.wav?�6:   �� 5   
      	InfoTitle#��[  6   $��
Proficiat!��67   $��10q�6I   �� 5   
   $ 
Horizontal=�6   $��Center=�6.   .+�5      ��   InfoMessage#��[ 6   $��Je behaalde het in: ��6=   �� 5      #��[ 6   ��6=   �� *TotalTime.Value+ �� StringFormat$ {0:hh}:{0:mm}:{0:ss}�� �� FallbackValue$ 00:00:00��6�   5      �� 5   
     Buttons#��[ 6   $��Ga terug naar begin��6L   ��62   �� *Click+6L   5      5      