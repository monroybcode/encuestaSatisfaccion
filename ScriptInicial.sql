GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Ind_Activo], [Discriminator]) VALUES (N'a3eec76a-a5b5-446b-8c86-fe3a37e25c3c', N'Administrador', 1, N'ApplicationRole')

INSERT [dbo].[AspNetUsers] ([Id], [UltimoIngreso], [NombreCompleto], [IndAct], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', N'25/09/2020 08:42', N'Dev Super Administrador', 1, N'itranquilino@bcodemexico.com', 0, N'AA2Shk8MdSC5MuKy3Ch57b2LHkSr0fPqAbHNwcDLWknp8XoCWguk+HWnuMMyeXlPOA==', N'1b737392-1669-4933-aebb-a88b9a60099c', NULL, 0, 0, NULL, 1, 0, N'sysadmin')

GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', N'a3eec76a-a5b5-446b-8c86-fe3a37e25c3c')
GO
SET IDENTITY_INSERT [dbo].[Funciones] ON 
GO
INSERT [dbo].[Funciones] ([Id_Funcion], [NombreCorto], [Nombre], [Ind_Activo]) VALUES (1, N'F1', N'Administración Usuarios', 1)
GO
INSERT [dbo].[Funciones] ([Id_Funcion], [NombreCorto], [Nombre], [Ind_Activo]) VALUES (2, N'F2', N'Administración Roles', 1)
GO
INSERT [dbo].[Funciones] ([Id_Funcion], [NombreCorto], [Nombre], [Ind_Activo]) VALUES (3, N'F3', N'Captura de Encuestados', 1)
GO
INSERT [dbo].[Funciones] ([Id_Funcion], [NombreCorto], [Nombre], [Ind_Activo]) VALUES (4, N'F4', N'Captura de Vigencia', 1)
GO
INSERT [dbo].[Funciones] ([Id_Funcion], [NombreCorto], [Nombre], [Ind_Activo]) VALUES (5, N'F5', N'Reporte Respuestas', 1)
GO

SET IDENTITY_INSERT [dbo].[Funciones] OFF
GO

GO
SET IDENTITY_INSERT [dbo].[UnidadesMedicas] ON 
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (1, 1101, N'HSM MORELIA', 1, NULL, NULL, NULL, NULL, NULL, 55)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (2, 1102, N'HSM AGUASCALIENTES', 1, NULL, NULL, NULL, NULL, NULL, 11)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (3, 1103, N'HSM MERIDA', 1, NULL, NULL, NULL, NULL, NULL, 3)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (4, 1104, N'HSM JUAREZ', 1, NULL, NULL, NULL, NULL, NULL, 2)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (5, 1105, N'HSM SAN LUIS POTOSÍ', 1, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (7, 1107, N'HOSPITAL INFANTIL PRIVADO', 1, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (8, 1109, N'HSM LOMAS VERDES', 1, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (9, 1110, N'VIVO JARDÍN BICENTENARIO', 1, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (10, 1111, N'VIVO CIUDAD AZTECA', 1, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (11, 1112, N'HSM LUNA PARC', 1, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (12, 1113, N'HSM QUERETARO', 1, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (13, 1114, N'HSM CHIHUAHUA', 1, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (14, 1115, N'HSM VERACRUZ', 1, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (20, 1106, N'HSM CENTRO', 1, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[UnidadesMedicas] ([Id_UnidadMedica], [ClaveUnidad], [UnidadMedica], [active], [Direccion], [UsuarioJuridico], [UsuarioCoordinador], [Domicilio], [Correo], [Consecutivo]) VALUES (21, 1119, N'HSM TLALNEPANTLA', 1, NULL, NULL, NULL, NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[UnidadesMedicas] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioxUmedica] ON 
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (125, 1, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.357' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (126, 2, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.373' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (127, 3, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.373' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (128, 4, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.373' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (129, 5, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.373' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (130, 7, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.390' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (131, 8, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.390' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (132, 9, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.390' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (133, 10, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.403' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (134, 11, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.403' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (135, 12, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.403' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (136, 13, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.420' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (137, 14, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.420' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (138, 20, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.420' AS DateTime))
GO
INSERT [dbo].[UsuarioxUmedica] ([Id_UUN], [Id_unidad], [UserID], [FechaAlta]) VALUES (139, 21, N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90', CAST(N'2020-09-18T17:08:47.437' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UsuarioxUmedica] OFF
GO

insert into VigenciaEnc (Dias,Activo,FechaAlta,UserCap) values(5,1,getdate(),'fb88da9f-e04a-4889-8ea3-86dd5bc68a90')
GO

update AspNetUsers set UserName='itranquilino@bcodemexico.com', PasswordHash='540aa3661440699ae8cca4593d41ee8e812389ba'

SET IDENTITY_INSERT [dbo].[FuncionesXRols] ON 
GO

INSERT [dbo].[FuncionesXRols] ([Id_FuncionesXRol], [Id_Funcion], [Id_Rol], [FechaAlta], [UserID]) VALUES (1, 1, N'a3eec76a-a5b5-446b-8c86-fe3a37e25c3c', CAST(N'2020-09-08T09:25:30.550' AS DateTime), N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90')
GO
INSERT [dbo].[FuncionesXRols] ([Id_FuncionesXRol], [Id_Funcion], [Id_Rol], [FechaAlta], [UserID]) VALUES (2, 2, N'a3eec76a-a5b5-446b-8c86-fe3a37e25c3c', CAST(N'2020-09-08T09:25:30.550' AS DateTime), N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90')
GO
INSERT [dbo].[FuncionesXRols] ([Id_FuncionesXRol], [Id_Funcion], [Id_Rol], [FechaAlta], [UserID]) VALUES (3, 3, N'a3eec76a-a5b5-446b-8c86-fe3a37e25c3c', CAST(N'2020-09-08T09:25:30.550' AS DateTime), N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90')
GO
INSERT [dbo].[FuncionesXRols] ([Id_FuncionesXRol], [Id_Funcion], [Id_Rol], [FechaAlta], [UserID]) VALUES (4, 4, N'a3eec76a-a5b5-446b-8c86-fe3a37e25c3c', CAST(N'2020-09-08T09:25:30.550' AS DateTime), N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90')
GO
INSERT [dbo].[FuncionesXRols] ([Id_FuncionesXRol], [Id_Funcion], [Id_Rol], [FechaAlta], [UserID]) VALUES (5, 5, N'a3eec76a-a5b5-446b-8c86-fe3a37e25c3c', CAST(N'2020-09-08T09:25:30.550' AS DateTime), N'fb88da9f-e04a-4889-8ea3-86dd5bc68a90')
GO

SET IDENTITY_INSERT [dbo].[FuncionesXRols] OFF
select * from FuncionesXRols
select * from Funciones
select * from AspNetRoles