   M S B A M L   `   `   `  ����C  ?Trabajo1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Trabajo1Trabajo1  5   	   !    Trabajo1.VentaGenerarequipo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Trabajo1     5   	   
���i��  � Title$  VentaGenerarequipo��5	   	   $	��450��6$   $	��800��61   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      �� -   5         ��Name$ btnNuevo��5      .��6>   Nuevo6E   �� 5      -   5        $ 	btnEditar��5      .��6@   Editar6H   �� 5      -   5        $ 
btnGuardar��5      .��6B   	Guardar6K   �� 5      -   5        $ btnCancelar��5      .��6D   
Cancelar6N   �� 5      -   5        $ btnEliminar��5      .��6D   
Eliminar6N   5      � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� Id:6!   �� 5      $	��200��6   6+   5      �� 5      $ 
Horizontal=�6   .+�5      �� .��6   Nombre de Deporte6+   �� 5      -   5        $��cmbNuevoDeporte��5      $	��100��62   6@   5       �� 5!      $ 
Horizontal=�6   .+�5"      �� .��6   Nombre del Equipo6+   �� 5#      -   5         ��Name$ txbNombreEquipo��5#      $	��130��63   6A   5$      �� 5%      $ 
Horizontal=�6   .+�5&      �� .��6   $"Cantidad de integrantes del equipo6<   �� 5'      -   5        $ txbCantidadIntegrantes��5'      $	��130��6:   6H   5(      5*      &   System.Windows.Controls.DataGrid  5+   
   -	   5          Name$ 	dtgEquipo��5+      $��2��6&      
IsReadOnly . 63   5-      5.      