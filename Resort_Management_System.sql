Create Database Resort_Management_System;

/*Admin................................................*/


/*TABLE 1: ROOM TABLE*/
Create Table Room_tbl(ROOM_ID int identity(1,1) Not Null,
					  CATEGORY varchar(50) Null,
					  ROOM_TYPE varchar(50) Null,
					  ROOM_DESCRIPT varchar(50) Null,
					  ROOM_CHARGES varchar(50) Null,
					  R_STATUS varchar(50) Null,
					  Primary Key(ROOM_ID));

/*TABLE 2: ADD FOOD ITEM TABLE.............................................*/

Create Table F_ORDER_tbl(ORDER_ID int Null,
						FOOD_ID varchar(50) Null,
						FOOD_NAME varchar(50) Null,
						FOOD_TYPE varchar(50) Null,
						CATEGORY varchar(50) Null,
						PRICE varchar(50) Null,
						QUANTITY varchar(50) Null,
						TOTAL_FOODPRICE varchar(50) Null,
						TABLE_NO int null,
						TABLE_CHARGES varchar(50) null,
						ROOM_ID int not null,
						MEMBER_ID int not null,
						TOTAL_PAYMENT varchar(50) null);

Alter Table F_ORDER_tbl DROP COLUMN FOOD_NAME ;

Alter Table F_ORDER_tbl DROP COLUMN FOOD_ID ;
Alter Table F_ORDER_tbl DROP COLUMN FOOD_TYPE ;
Alter Table F_ORDER_tbl DROP COLUMN CATEGORY ;
Alter Table F_ORDER_tbl DROP COLUMN PRICE ;
Alter Table F_ORDER_tbl DROP COLUMN QUANTITY ;
Alter Table F_ORDER_tbl DROP COLUMN TOTAL_FOODPRICE ;

/*Multiple Food orders Table..........................................*/				
CREATE TABLE FOOD_ORDER_ITEM_TBL(FOI_ID int identity(1,1),
								 ORDER_ID varchar(50),
								 FOOD_ID varchar(50),
								 FOOD_TYPE varchar(50),
								 FOOD_NAME varchar(50),
								 CATEGORY varchar(50),
								 F_QUANTITY varchar(50),
								 F_PRICE varchar(50),
								 TOTAL_PRICE varchar(50),
								 primary key(FOI_ID));

/*TABLE 3: SERVICE AAVIL TABLE.............................................*/

Create Table Service_AVAIL_tbl(SERVICE_ID int identity(1,1)Not Null,
								 MEMBER_ID int not null,
								 NO_OF_PERSON varchar(50) null,
								 PSERVICE_ID int not null,
								 S_DATE DATE null,
								 PRIMARY KEY(SERVICE_ID),
								 Foreign Key(MEMBER_ID) references Member_tbl(MEMBER_ID),
								 Foreign Key(PSERVICE_ID) references Service_Provide_tbl(PSERVICE_ID));

ALTER table Service_AVAIL_tbl Add PSERVICE_NAME varchar(50);


/*TABLE 4: SERVICE AAVIL TABLE.............................................*/

Create Table S_Avail2_tbl(S_ID int identity(1,1)Not Null,
								 SERVICE_ID int not null,
								 MEMBER_ID int not null,
								 PSERVICE_ID int not null,
								 PRIMARY KEY(S_ID),
								 Foreign Key(MEMBER_ID) references Member_tbl(MEMBER_ID),
								  Foreign Key(PSERVICE_ID) references Service_Provide_tbl(PSERVICE_ID),
								 Foreign Key(SERVICE_ID) references Service_AVAIL_tbl(SERVICE_ID));
ALTER table S_Avail2_tbl Add SERVICE_CHARGES varchar(50);


/*TABLE 5: EMPLOYEES TABLE.............................................*/

Create Table Employee_tbl(EMP_ID int identity(1,1)Not null,
						  EMP_NAME varchar(50) null,
						  DEPART varchar(50) null,
						  AGE varchar(50) null,
						  PHONE_NO varchar(50) null,
						  JOB_TYPE varchar(50) null,
						  RESPONSIBILITY varchar(50) null,
						  SALARY varchar(50) 
						  PRIMARY KEY(EMP_ID));

Alter table Employee_tbl Add EMP_STATUS varchar(50);
ALTER TABLE "table_name" Change "column 1" "column 2" ["Data Type"];
ALTER TABLE Employee_tbl ALTER COLUMN "RESPONSIBILITY" TO "SALARY"[]

sp_rename 'Employee_tbl.SALARY', 'RESPONS', 'COLUMN';
sp_rename 'employees.RESPONSIBILITY', 'SAL', 'COLUMN';

ALTER TABLE Employee_tbl DROP COLUMN RESPONSIBILITY;
Alter table Employee_tbl Add SALARY varchar(50);


/*TABLE 6: PO TABLE.............................................*/

Create table PO_tbl(PO_ID int identity(1,1) Not Null,
					DEPART varchar(50) null,
					COMPANY_ID int not null,
					ITEM_TYPE varchar(50) null,
					DESCRIPT varchar(50) null,
					QUANTITY varchar(50) null,
					PO_DATE date null,
					DELIVARY_DATE date null,
					TOTAL_AMOUNT varchar(50) null,
					Primary Key(PO_ID),
					Foreign Key(COMPANY_ID) references COMPANY_tbl(COMPANY_ID));
ALTER TABLE PO_tbl ADD ITEM_ID varchar(50);


/*TABLE 7: PO_PRODUCT TABLE.............................................*/

Create table PO_Product_tbl(POP_ID int identity(1,1) Not Null,
							PO_ID int not null,
							ITEM_ID int not null,
							ITEM_TYPE varchar(50) null,
							QUANTITY varchar(50) null,
							TOTAL_AMOUNT varchar(50) null,
							PRIMARY KEY(POP_ID),
							Foreign Key(PO_ID) references PO_tbl(PO_ID));



/*TABLE 8: COMPANY TABLE.............................................*/

Create table COMPANY_tbl(COMPANY_ID int identity(1,1) Not Null,
						 COMPANY_NAME varchar(50) null,
						 COMPANY_TYPE varchar(50) null,
						 PHONE_NO varchar(50) null,
						 PRIMARY KEY(COMPANY_ID));

ALTER TABLE COMPANY_tbl ADD ITEM1_ID int;
ALTER TABLE COMPANY_tbl ADD ITEM_NAME varchar(50);

/*TABLE 9: GRN TABLE.............................................*/

CREATE TABLE GRNP_tbl(GRN_ID int identity(1,1) not null,
					 GRN_DATE date null,
					 PO_ID int not null,
					 DEPARTMENT varchar(50) null,
					 COMPANY_ID int not null,
					 COMPANY_NAME varchar(50) null,
					 ITEM_ID int not null,
					 ITEM_TYPE varchar(50) null,
					 QUANTITY varchar(50) null,
					 TOTAL_PRICE varchar(50) null,
					 PRIMARY KEY(GRN_ID),
					 Foreign Key(PO_ID) references PO_tbl(PO_ID),
					 Foreign Key(COMPANY_ID) references COMPANY_tbl(COMPANY_ID));

/*TABLE 10: INVOICE TABLE.............................................*/

CREATE TABLE INVOICE1_tbl(INVOICE_ID int identity(1,1) not null,
						 INVOICE_DATE date null,
						 DEPARTMENT varchar(50) null,
						 COMPANY_ID int not null,
					     COMPANY_NAME varchar(50) null,
					     ITEM_ID int not null,
					     ITEM_TYPE varchar(50) null,
					     QUANTITY varchar(50) null,
					     TOTAL_PRICE varchar(50) null,
						 PRIMARY KEY(INVOICE_ID),
						 Foreign Key(COMPANY_ID) references COMPANY_tbl(COMPANY_ID));


/*Customer................................................*/
/*TABLE 11: ROOM TABLE.............................................*/

Create Table Room_Booking_tbl(R_BOOK_ID int identity(1,1) Not Null,
						   MEMBER_ID INT NOT NULL,
						   MEMBER_NAME varchar(50),
						   MEMBER_TYPE varchar(50),
						   PHONE_NO varchar(50),
						   NO_OF_PERSON varchar(50),
						   CATEGORY varchar(50),
						   ROOM_TYPE varchar(50),
						   ROOM_ID varchar(50),
						   ROOM_DESCRIPT varchar(50),
						   ROOM_CHARGES varchar(50),
						   T_NO_DAYS varchar(50),
					  Primary Key(R_BOOK_ID),
					  Foreign Key(MEMBER_ID) references Member_tbl(MEMBER_ID));
ALTER Room_Booking_tbl ADD COLUMN CHECH_IN date


/*TABLE 12: MEMBER TABLE.............................................*/
Create Table Member_tbl(MEMBER_ID int identity(1,1)Not Null,
						MEMBER_NAME varchar(50) Null,
						PHONE_NO varchar(50) Null,
						E_MAIL varchar(50) Null,
						USERNAME varchar(50) Null,
						U_PASSWORD varchar(50) Null,
						M_ADDRESS varchar(50) Null,
						MEMBER_TYPE varchar(50) Null,
						MEMBERSHIP_ID varchar(50) Null,
						MEMBERSHIP_CHARGES varchar(50) Null,
						M_STATUS varchar(50) Null,
						Primary key(MEMBER_ID));



/*TABLE 13: ADD FOOD ITEM TABLE.............................................*/

Create Table FOODITEM_tbl(FOOD_ID int identity(1,1)Not Null,
						FOOD_NAME varchar(50) Null,
						FOOD_TYPE varchar(50) Null,
						CATEGORY varchar(50) Null,
						COMPANY_NAME varchar(50) Null,
						PRICE varchar(50) Null,
						QUANTITY varchar(50) Null,
						TOTAL_PRICE varchar(50) Null,
						Primary key(FOOD_ID));

/*TABLE 14: SERVICE PROVIDING TABLE.............................................*/

Create Table Service_Provide_tbl(PSERVICE_ID int identity(1,1)Not Null,
								 PSERVICE_NAME varchar(50) null,
								 AVAIL_TO varchar(50) null,
								 AVAIL_POINTS varchar(50) null,
								 SERVICE_STATUS varchar(50) null,
								 SERVICE_HEAD_NAME varchar(50) null,
								 WORKERS varchar(50) null,
								 SERVICE_CHARGES varchar(50) null,
								 PRIMARY KEY(PSERVICE_ID));

/*TABLE 15: BILL PAYMENT TABLE.............................................*/

CREATE TABLE BILL_tbl(BILL_ID int identity(1,1)Not Null,
					  MEMBER_ID int not null,
					  MEMBER_NAME varchar(50) null,
					  MEMBER_TYPE varchar(50) null,
					  CHECK_IN date null,
					  CHECK_OUT date null,
					  ROOM_CHARGES varchar(50) null,
					  FOOD_CHARGES varchar(50) null,
					  SERVICE_CHARGES varchar(50) null,
					  MEMBERSHIP_CHARGES varchar(50) null,
					  TOTAL_PAYMENT varchar(50) null,
					  primary key(BILL_ID));