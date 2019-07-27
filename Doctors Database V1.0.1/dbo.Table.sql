CREATE TABLE [dbo].[Table] 
(
    [DoctorID]   INT           IDENTITY (1, 1) NOT NULL,
    [FullName]   VARCHAR (200) NOT NULL,
    [Speciality] VARCHAR (200) NULL,
    [Phone]      VARCHAR (30)  NULL,
    [Address]    VARCHAR (300) NULL,
    [Email]      VARCHAR (70)  NULL,
    PRIMARY KEY CLUSTERED ([DoctorID] ASC)
);

