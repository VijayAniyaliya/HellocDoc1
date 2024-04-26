toc.dat                                                                                             0000600 0004000 0002000 00000317530 14612723503 0014453 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP       &                |            HalloDocMVC    16.1    16.1    n           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false         o           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false         p           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false         q           1262    98869    HalloDocMVC    DATABASE     �   CREATE DATABASE "HalloDocMVC" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';
    DROP DATABASE "HalloDocMVC";
                postgres    false         �            1259    98870    Admin    TABLE     �  CREATE TABLE public."Admin" (
    "AdminId" integer NOT NULL,
    "AspNetUserId" character varying(128) NOT NULL,
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(100),
    "RegionId" integer,
    "Zip" character varying(10),
    "AltPhone" character varying(20),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" bit(1),
    "RoleId" integer
);
    DROP TABLE public."Admin";
       public         heap    postgres    false         �            1259    98875    AdminRegion    TABLE     �   CREATE TABLE public."AdminRegion" (
    "AdminRegionId" integer NOT NULL,
    "AdminId" integer NOT NULL,
    "RegionId" integer NOT NULL
);
 !   DROP TABLE public."AdminRegion";
       public         heap    postgres    false         �            1259    98878    AdminRegion_AdminRegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."AdminRegion_AdminRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public."AdminRegion_AdminRegionId_seq";
       public          postgres    false    216         r           0    0    AdminRegion_AdminRegionId_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public."AdminRegion_AdminRegionId_seq" OWNED BY public."AdminRegion"."AdminRegionId";
          public          postgres    false    217         �            1259    98879    Admin_AdminId_seq    SEQUENCE     �   CREATE SEQUENCE public."Admin_AdminId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."Admin_AdminId_seq";
       public          postgres    false    215         s           0    0    Admin_AdminId_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."Admin_AdminId_seq" OWNED BY public."Admin"."AdminId";
          public          postgres    false    218         �            1259    98880    AspNetRoles    TABLE     |   CREATE TABLE public."AspNetRoles" (
    "Id" character varying(128) NOT NULL,
    "Name" character varying(256) NOT NULL
);
 !   DROP TABLE public."AspNetRoles";
       public         heap    postgres    false         �            1259    98883    AspNetUserRoles    TABLE     �   CREATE TABLE public."AspNetUserRoles" (
    "UserId" character varying(128) NOT NULL,
    "RoleId" character varying(128) NOT NULL
);
 %   DROP TABLE public."AspNetUserRoles";
       public         heap    postgres    false         �            1259    98886    AspNetUsers    TABLE     {  CREATE TABLE public."AspNetUsers" (
    "Id" character varying(128) NOT NULL,
    "UserName" character varying(256) NOT NULL,
    "PasswordHash" character varying,
    "Email" character varying(256),
    "PhoneNumber" character varying(20),
    "IP" character varying(20),
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedDate" timestamp without time zone
);
 !   DROP TABLE public."AspNetUsers";
       public         heap    postgres    false         �            1259    98891    BlockRequests    TABLE     }  CREATE TABLE public."BlockRequests" (
    "BlockRequestId" integer NOT NULL,
    "PhoneNumber" character varying(50),
    "Email" character varying(50),
    "IsActive" bit(1),
    "Reason" character varying,
    "RequestId" character varying NOT NULL,
    "IP" character varying(20),
    "CreatedDate" timestamp without time zone,
    "ModifiedDate" timestamp without time zone
);
 #   DROP TABLE public."BlockRequests";
       public         heap    postgres    false         �            1259    98896     BlockRequests_BlockRequestId_seq    SEQUENCE     �   CREATE SEQUENCE public."BlockRequests_BlockRequestId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public."BlockRequests_BlockRequestId_seq";
       public          postgres    false    222         t           0    0     BlockRequests_BlockRequestId_seq    SEQUENCE OWNED BY     k   ALTER SEQUENCE public."BlockRequests_BlockRequestId_seq" OWNED BY public."BlockRequests"."BlockRequestId";
          public          postgres    false    223         �            1259    98897    Business    TABLE     �  CREATE TABLE public."Business" (
    "BusinessId" integer NOT NULL,
    "Name" character varying(100) NOT NULL,
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(50),
    "RegionId" integer,
    "ZipCode" character varying(10),
    "PhoneNumber" character varying(20),
    "FaxNumber" character varying(20),
    "IsRegistered" bit(1),
    "CreatedBy" character varying(128),
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" bit(1),
    "IP" character varying(20)
);
    DROP TABLE public."Business";
       public         heap    postgres    false         �            1259    98902    Business_BusinessId_seq    SEQUENCE     �   CREATE SEQUENCE public."Business_BusinessId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."Business_BusinessId_seq";
       public          postgres    false    224         u           0    0    Business_BusinessId_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."Business_BusinessId_seq" OWNED BY public."Business"."BusinessId";
          public          postgres    false    225         �            1259    98903    CaseTag    TABLE     o   CREATE TABLE public."CaseTag" (
    "CaseTagId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);
    DROP TABLE public."CaseTag";
       public         heap    postgres    false         �            1259    98906    CaseTag_CaseTagId_seq    SEQUENCE     �   CREATE SEQUENCE public."CaseTag_CaseTagId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."CaseTag_CaseTagId_seq";
       public          postgres    false    226         v           0    0    CaseTag_CaseTagId_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public."CaseTag_CaseTagId_seq" OWNED BY public."CaseTag"."CaseTagId";
          public          postgres    false    227         �            1259    98907 	   Concierge    TABLE     �  CREATE TABLE public."Concierge" (
    "ConciergeId" integer NOT NULL,
    "ConciergeName" character varying(100) NOT NULL,
    "Address" character varying(150),
    "Street" character varying(50) NOT NULL,
    "City" character varying(50) NOT NULL,
    "State" character varying(50) NOT NULL,
    "ZipCode" character varying(50) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "RegionId" integer NOT NULL,
    "RoleId" character varying(20)
);
    DROP TABLE public."Concierge";
       public         heap    postgres    false         �            1259    98910    Concierge_ConciergeId_seq    SEQUENCE     �   CREATE SEQUENCE public."Concierge_ConciergeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public."Concierge_ConciergeId_seq";
       public          postgres    false    228         w           0    0    Concierge_ConciergeId_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public."Concierge_ConciergeId_seq" OWNED BY public."Concierge"."ConciergeId";
          public          postgres    false    229         �            1259    98911    EmailLog    TABLE     8  CREATE TABLE public."EmailLog" (
    "EmailLogID" integer NOT NULL,
    "EmailTemplate" character varying NOT NULL,
    "SubjectName" character varying(200) NOT NULL,
    "EmailID" character varying(200) NOT NULL,
    "ConfirmationNumber" character varying(200),
    "FilePath" character varying,
    "RoleId" integer,
    "RequestId" integer,
    "AdminId" integer,
    "PhysicianId" integer,
    "CreateDate" timestamp without time zone NOT NULL,
    "SentDate" timestamp without time zone,
    "IsEmailSent" bit(1),
    "SentTries" integer,
    "Action" integer
);
    DROP TABLE public."EmailLog";
       public         heap    postgres    false         �            1259    98916    EmailLog_EmailLogID_seq    SEQUENCE     �   ALTER TABLE public."EmailLog" ALTER COLUMN "EmailLogID" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."EmailLog_EmailLogID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    230         �            1259    98917    EncounterForm    TABLE     �  CREATE TABLE public."EncounterForm" (
    "EncounterFormId" integer NOT NULL,
    "RequestId" integer,
    "HistoryOfPresentIllnessOrInjury" text,
    "MedicalHistory" text,
    "Medications" text,
    "Allergies" text,
    "Temp" text,
    "HR" text,
    "RR" text,
    "BloodPressureSystolic" text,
    "BloodPressureDiastolic" text,
    "O2" text,
    "Pain" text,
    "Heent" text,
    "CV" text,
    "Chest" text,
    "ABD" text,
    "Extremeties" text,
    "Skin" text,
    "Neuro" text,
    "Other" text,
    "Diagnosis" text,
    "TreatmentPlan" text,
    "MedicationsDispensed" text,
    "Procedures" text,
    "FollowUp" text,
    "AdminId" integer,
    "PhysicianId" integer,
    "IsFinalize" boolean DEFAULT false NOT NULL
);
 #   DROP TABLE public."EncounterForm";
       public         heap    postgres    false         �            1259    98923 !   EncounterForm_EncounterFormId_seq    SEQUENCE     �   CREATE SEQUENCE public."EncounterForm_EncounterFormId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 :   DROP SEQUENCE public."EncounterForm_EncounterFormId_seq";
       public          postgres    false    232         x           0    0 !   EncounterForm_EncounterFormId_seq    SEQUENCE OWNED BY     m   ALTER SEQUENCE public."EncounterForm_EncounterFormId_seq" OWNED BY public."EncounterForm"."EncounterFormId";
          public          postgres    false    233         �            1259    98924    HealthProfessionalType    TABLE     �   CREATE TABLE public."HealthProfessionalType" (
    "HealthProfessionalId" integer NOT NULL,
    "ProfessionName" character varying(50) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "IsActive" bit(1),
    "IsDeleted" bit(1)
);
 ,   DROP TABLE public."HealthProfessionalType";
       public         heap    postgres    false         �            1259    98927 /   HealthProfessionalType_HealthProfessionalId_seq    SEQUENCE     �   CREATE SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 H   DROP SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq";
       public          postgres    false    234         y           0    0 /   HealthProfessionalType_HealthProfessionalId_seq    SEQUENCE OWNED BY     �   ALTER SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq" OWNED BY public."HealthProfessionalType"."HealthProfessionalId";
          public          postgres    false    235         �            1259    98928    HealthProfessionals    TABLE     �  CREATE TABLE public."HealthProfessionals" (
    "VendorId" integer NOT NULL,
    "VendorName" character varying(100) NOT NULL,
    "Profession" integer,
    "FaxNumber" character varying(50) NOT NULL,
    "Address" character varying(150),
    "City" character varying(100),
    "State" character varying(50),
    "Zip" character varying(50),
    "RegionId" integer,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedDate" timestamp without time zone,
    "PhoneNumber" character varying(100),
    "IsDeleted" bit(1),
    "IP" character varying(20),
    "Email" character varying(50),
    "BusinessContact" character varying(100)
);
 )   DROP TABLE public."HealthProfessionals";
       public         heap    postgres    false         �            1259    98933     HealthProfessionals_VendorId_seq    SEQUENCE     �   CREATE SEQUENCE public."HealthProfessionals_VendorId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public."HealthProfessionals_VendorId_seq";
       public          postgres    false    236         z           0    0     HealthProfessionals_VendorId_seq    SEQUENCE OWNED BY     k   ALTER SEQUENCE public."HealthProfessionals_VendorId_seq" OWNED BY public."HealthProfessionals"."VendorId";
          public          postgres    false    237         �            1259    98934    Menu    TABLE     �   CREATE TABLE public."Menu" (
    "MenuId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "AccountType" smallint NOT NULL,
    "SortOrder" integer
);
    DROP TABLE public."Menu";
       public         heap    postgres    false         �            1259    98937    Menu_MenuId_seq    SEQUENCE     �   CREATE SEQUENCE public."Menu_MenuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Menu_MenuId_seq";
       public          postgres    false    238         {           0    0    Menu_MenuId_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Menu_MenuId_seq" OWNED BY public."Menu"."MenuId";
          public          postgres    false    239         �            1259    98938    OrderDetails    TABLE     �  CREATE TABLE public."OrderDetails" (
    "Id" integer NOT NULL,
    "VendorId" integer,
    "RequestId" integer,
    "FaxNumber" character varying(50),
    "Email" character varying(50),
    "BusinessContact" character varying(100),
    "Prescription" character varying,
    "NoOfRefill" integer,
    "CreatedDate" timestamp without time zone,
    "CreatedBy" character varying(100)
);
 "   DROP TABLE public."OrderDetails";
       public         heap    postgres    false         �            1259    98943    OrderDetails_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."OrderDetails_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public."OrderDetails_Id_seq";
       public          postgres    false    240         |           0    0    OrderDetails_Id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public."OrderDetails_Id_seq" OWNED BY public."OrderDetails"."Id";
          public          postgres    false    241         �            1259    98944 	   Physician    TABLE     $  CREATE TABLE public."Physician" (
    "PhysicianId" integer NOT NULL,
    "AspNetUserId" character varying(128),
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "MedicalLicense" character varying(500),
    "Photo" character varying(100),
    "AdminNotes" character varying(500),
    "IsAgreementDoc" bit(1),
    "IsBackgroundDoc" bit(1),
    "IsTrainingDoc" bit(1),
    "IsNonDisclosureDoc" bit(1),
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(100),
    "RegionId" integer,
    "Zip" character varying(10),
    "AltPhone" character varying(20),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "BusinessName" character varying(100) NOT NULL,
    "BusinessWebsite" character varying(200) NOT NULL,
    "IsDeleted" bit(1),
    "RoleId" integer,
    "NPINumber" character varying(500),
    "IsLicenseDoc" bit(1),
    "Signature" character varying(100),
    "IsCredentialDoc" bit(1),
    "IsTokenGenerate" bit(1),
    "SyncEmailAddress" character varying(50)
);
    DROP TABLE public."Physician";
       public         heap    postgres    false         �            1259    98949    PhysicianLocation    TABLE     0  CREATE TABLE public."PhysicianLocation" (
    "LocationId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "Latitude" numeric(11,8),
    "Longitude" numeric(11,8),
    "CreatedDate" timestamp without time zone,
    "PhysicianName" character varying(50),
    "Address" character varying(500)
);
 '   DROP TABLE public."PhysicianLocation";
       public         heap    postgres    false         �            1259    98954     PhysicianLocation_LocationId_seq    SEQUENCE     �   CREATE SEQUENCE public."PhysicianLocation_LocationId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public."PhysicianLocation_LocationId_seq";
       public          postgres    false    243         }           0    0     PhysicianLocation_LocationId_seq    SEQUENCE OWNED BY     k   ALTER SEQUENCE public."PhysicianLocation_LocationId_seq" OWNED BY public."PhysicianLocation"."LocationId";
          public          postgres    false    244         �            1259    98955    PhysicianNotification    TABLE     �   CREATE TABLE public."PhysicianNotification" (
    id integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "IsNotificationStopped" bit(1) NOT NULL
);
 +   DROP TABLE public."PhysicianNotification";
       public         heap    postgres    false         �            1259    98958    PhysicianNotification_id_seq    SEQUENCE     �   CREATE SEQUENCE public."PhysicianNotification_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public."PhysicianNotification_id_seq";
       public          postgres    false    245         ~           0    0    PhysicianNotification_id_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public."PhysicianNotification_id_seq" OWNED BY public."PhysicianNotification".id;
          public          postgres    false    246         �            1259    98959    PhysicianRegion    TABLE     �   CREATE TABLE public."PhysicianRegion" (
    "PhysicianRegionId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "RegionId" integer NOT NULL
);
 %   DROP TABLE public."PhysicianRegion";
       public         heap    postgres    false         �            1259    98962 %   PhysicianRegion_PhysicianRegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq";
       public          postgres    false    247                    0    0 %   PhysicianRegion_PhysicianRegionId_seq    SEQUENCE OWNED BY     u   ALTER SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq" OWNED BY public."PhysicianRegion"."PhysicianRegionId";
          public          postgres    false    248         �            1259    98963    Physician_PhysicianId_seq    SEQUENCE     �   CREATE SEQUENCE public."Physician_PhysicianId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public."Physician_PhysicianId_seq";
       public          postgres    false    242         �           0    0    Physician_PhysicianId_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public."Physician_PhysicianId_seq" OWNED BY public."Physician"."PhysicianId";
          public          postgres    false    249         �            1259    98964    Region    TABLE     �   CREATE TABLE public."Region" (
    "RegionId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Abbreviation" character varying(50)
);
    DROP TABLE public."Region";
       public         heap    postgres    false         �            1259    98967    Region_RegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."Region_RegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public."Region_RegionId_seq";
       public          postgres    false    250         �           0    0    Region_RegionId_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public."Region_RegionId_seq" OWNED BY public."Region"."RegionId";
          public          postgres    false    251         �            1259    98968    Request    TABLE     5  CREATE TABLE public."Request" (
    "RequestId" integer NOT NULL,
    "RequestTypeId" integer NOT NULL,
    "UserId" integer,
    "FirstName" character varying(100),
    "LastName" character varying(100),
    "PhoneNumber" character varying(23),
    "Email" character varying(50),
    "Status" smallint NOT NULL,
    "PhysicianId" integer,
    "ConfirmationNumber" character varying(20),
    "CreatedDate" timestamp without time zone NOT NULL,
    "IsDeleted" bit(1),
    "ModifiedDate" timestamp without time zone,
    "DeclinedBy" character varying(250),
    "IsUrgentEmailSent" bit(1) NOT NULL,
    "LastWellnessDate" timestamp without time zone,
    "IsMobile" bit(1),
    "CallType" smallint,
    "CompletedByPhysician" bit(1),
    "LastReservationDate" timestamp without time zone,
    "AcceptedDate" timestamp without time zone,
    "RelationName" character varying(100),
    "CaseNumber" character varying(50),
    "IP" character varying(20),
    "CaseTag" character varying(50),
    "CaseTagPhysician" character varying(50),
    "PatientAccountId" character varying(128),
    "CreatedUserId" integer,
    CONSTRAINT "Request_RequestTypeId_check" CHECK (("RequestTypeId" = ANY (ARRAY[1, 2, 3, 4]))),
    CONSTRAINT "Request_Status_check" CHECK (("Status" = ANY (ARRAY[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15])))
);
    DROP TABLE public."Request";
       public         heap    postgres    false         �            1259    98975    RequestBusiness    TABLE     �   CREATE TABLE public."RequestBusiness" (
    "RequestBusinessId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "BusinessId" integer NOT NULL,
    "IP" character varying(20)
);
 %   DROP TABLE public."RequestBusiness";
       public         heap    postgres    false         �            1259    98978 %   RequestBusiness_RequestBusinessId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestBusiness_RequestBusinessId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public."RequestBusiness_RequestBusinessId_seq";
       public          postgres    false    253         �           0    0 %   RequestBusiness_RequestBusinessId_seq    SEQUENCE OWNED BY     u   ALTER SEQUENCE public."RequestBusiness_RequestBusinessId_seq" OWNED BY public."RequestBusiness"."RequestBusinessId";
          public          postgres    false    254         �            1259    98979    RequestClient    TABLE       CREATE TABLE public."RequestClient" (
    "RequestClientId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "PhoneNumber" character varying(23),
    "Location" character varying(100),
    "Address" character varying(500),
    "RegionId" integer,
    "NotiMobile" character varying(20),
    "NotiEmail" character varying(50),
    "Notes" character varying(500),
    "Email" character varying(50),
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "IsMobile" bit(1),
    "Street" character varying(100),
    "City" character varying(100),
    "State" character varying(100),
    "ZipCode" character varying(10),
    "CommunicationType" smallint,
    "RemindReservationCount" smallint,
    "RemindHouseCallCount" smallint,
    "IsSetFollowupSent" smallint,
    "IP" character varying(20),
    "IsReservationReminderSent" smallint,
    "Latitude" numeric(11,8),
    "Longitude" numeric(11,8)
);
 #   DROP TABLE public."RequestClient";
       public         heap    postgres    false                     1259    98984 !   RequestClient_RequestClientId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestClient_RequestClientId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 :   DROP SEQUENCE public."RequestClient_RequestClientId_seq";
       public          postgres    false    255         �           0    0 !   RequestClient_RequestClientId_seq    SEQUENCE OWNED BY     m   ALTER SEQUENCE public."RequestClient_RequestClientId_seq" OWNED BY public."RequestClient"."RequestClientId";
          public          postgres    false    256                    1259    98985    RequestClosed    TABLE       CREATE TABLE public."RequestClosed" (
    "RequestClosedId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "RequestStatusLogId" integer NOT NULL,
    "PhyNotes" character varying(500),
    "ClientNotes" character varying(500),
    "IP" character varying(20)
);
 #   DROP TABLE public."RequestClosed";
       public         heap    postgres    false                    1259    98990 !   RequestClosed_RequestClosedId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestClosed_RequestClosedId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 :   DROP SEQUENCE public."RequestClosed_RequestClosedId_seq";
       public          postgres    false    257         �           0    0 !   RequestClosed_RequestClosedId_seq    SEQUENCE OWNED BY     m   ALTER SEQUENCE public."RequestClosed_RequestClosedId_seq" OWNED BY public."RequestClosed"."RequestClosedId";
          public          postgres    false    258                    1259    98991    RequestConcierge    TABLE     �   CREATE TABLE public."RequestConcierge" (
    "Id" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "ConciergeId" integer NOT NULL,
    "IP" character varying(20)
);
 &   DROP TABLE public."RequestConcierge";
       public         heap    postgres    false                    1259    98994    RequestConcierge_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestConcierge_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."RequestConcierge_Id_seq";
       public          postgres    false    259         �           0    0    RequestConcierge_Id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."RequestConcierge_Id_seq" OWNED BY public."RequestConcierge"."Id";
          public          postgres    false    260                    1259    98995    RequestNotes    TABLE     .  CREATE TABLE public."RequestNotes" (
    "RequestNotesId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "PhysicianNotes" character varying(500),
    "AdminNotes" character varying(500),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "IP" character varying(20),
    "AdministrativeNotes" character varying(500)
);
 "   DROP TABLE public."RequestNotes";
       public         heap    postgres    false                    1259    99000    RequestNotes_RequestNotesId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestNotes_RequestNotesId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 8   DROP SEQUENCE public."RequestNotes_RequestNotesId_seq";
       public          postgres    false    261         �           0    0    RequestNotes_RequestNotesId_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public."RequestNotes_RequestNotesId_seq" OWNED BY public."RequestNotes"."RequestNotesId";
          public          postgres    false    262                    1259    99001    RequestStatusLog    TABLE     �  CREATE TABLE public."RequestStatusLog" (
    "RequestStatusLogId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "Status" smallint NOT NULL,
    "PhysicianId" integer,
    "AdminId" integer,
    "TransToPhysicianId" integer,
    "Notes" character varying(500),
    "CreatedDate" timestamp without time zone NOT NULL,
    "IP" character varying(20),
    "TransToAdmin" bit(1)
);
 &   DROP TABLE public."RequestStatusLog";
       public         heap    postgres    false                    1259    99006 '   RequestStatusLog_RequestStatusLogId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 @   DROP SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq";
       public          postgres    false    263         �           0    0 '   RequestStatusLog_RequestStatusLogId_seq    SEQUENCE OWNED BY     y   ALTER SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq" OWNED BY public."RequestStatusLog"."RequestStatusLogId";
          public          postgres    false    264         	           1259    99007    RequestType    TABLE     w   CREATE TABLE public."RequestType" (
    "RequestTypeId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);
 !   DROP TABLE public."RequestType";
       public         heap    postgres    false         
           1259    99010    RequestType_RequestTypeId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestType_RequestTypeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public."RequestType_RequestTypeId_seq";
       public          postgres    false    265         �           0    0    RequestType_RequestTypeId_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public."RequestType_RequestTypeId_seq" OWNED BY public."RequestType"."RequestTypeId";
          public          postgres    false    266                    1259    99011    RequestWiseFile    TABLE     *  CREATE TABLE public."RequestWiseFile" (
    "RequestWiseFileID" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "FileName" character varying(500) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "PhysicianId" integer,
    "AdminId" integer,
    "DocType" smallint,
    "IsFrontSide" bit(1),
    "IsCompensation" bit(1),
    "IP" character varying(20),
    "IsFinalize" bit(1),
    "IsDeleted" bit(1),
    "IsPatientRecords" bit(1),
    CONSTRAINT "RequestWiseFile_DocType_check" CHECK (("DocType" = ANY (ARRAY[1, 2, 3])))
);
 %   DROP TABLE public."RequestWiseFile";
       public         heap    postgres    false                    1259    99017 %   RequestWiseFile_RequestWiseFileID_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq";
       public          postgres    false    267         �           0    0 %   RequestWiseFile_RequestWiseFileID_seq    SEQUENCE OWNED BY     u   ALTER SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq" OWNED BY public."RequestWiseFile"."RequestWiseFileID";
          public          postgres    false    268                    1259    99018    Request_RequestId_seq    SEQUENCE     �   CREATE SEQUENCE public."Request_RequestId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."Request_RequestId_seq";
       public          postgres    false    252         �           0    0    Request_RequestId_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public."Request_RequestId_seq" OWNED BY public."Request"."RequestId";
          public          postgres    false    269                    1259    99019    Role    TABLE     �  CREATE TABLE public."Role" (
    "RoleId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "IsDeleted" bit(1) NOT NULL,
    "IP" character varying(20),
    "AccountType" smallint DEFAULT 1 NOT NULL,
    CONSTRAINT "Role_AccountType_check" CHECK (("AccountType" = ANY (ARRAY[1, 2, 3, 4])))
);
    DROP TABLE public."Role";
       public         heap    postgres    false                    1259    99024    RoleMenu    TABLE     �   CREATE TABLE public."RoleMenu" (
    "RoleMenuId" integer NOT NULL,
    "RoleId" integer NOT NULL,
    "MenuId" integer NOT NULL
);
    DROP TABLE public."RoleMenu";
       public         heap    postgres    false                    1259    99027    RoleMenu_RoleMenuId_seq    SEQUENCE     �   CREATE SEQUENCE public."RoleMenu_RoleMenuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."RoleMenu_RoleMenuId_seq";
       public          postgres    false    271         �           0    0    RoleMenu_RoleMenuId_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."RoleMenu_RoleMenuId_seq" OWNED BY public."RoleMenu"."RoleMenuId";
          public          postgres    false    272                    1259    99028    Role_RoleId_seq    SEQUENCE     �   CREATE SEQUENCE public."Role_RoleId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Role_RoleId_seq";
       public          postgres    false    270         �           0    0    Role_RoleId_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Role_RoleId_seq" OWNED BY public."Role"."RoleId";
          public          postgres    false    273                    1259    99029    SMSLog    TABLE     �  CREATE TABLE public."SMSLog" (
    "SMSLogID" integer NOT NULL,
    "SMSTemplate" character varying NOT NULL,
    "MobileNumber" character varying(50) NOT NULL,
    "ConfirmationNumber" character varying(200),
    "RoleId" integer,
    "AdminId" integer,
    "RequestId" integer,
    "PhysicianId" integer,
    "CreateDate" timestamp without time zone NOT NULL,
    "SentDate" timestamp without time zone,
    "IsSMSSent" bit(1),
    "SentTries" integer NOT NULL,
    "Action" integer
);
    DROP TABLE public."SMSLog";
       public         heap    postgres    false                    1259    99034    SMSLog_SMSLogID_seq    SEQUENCE     �   ALTER TABLE public."SMSLog" ALTER COLUMN "SMSLogID" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."SMSLog_SMSLogID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    274                    1259    99035    Shift    TABLE     c  CREATE TABLE public."Shift" (
    "ShiftId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "StartDate" date NOT NULL,
    "IsRepeat" bit(1) NOT NULL,
    "WeekDays" character(7),
    "RepeatUpto" integer,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "IP" character varying(20)
);
    DROP TABLE public."Shift";
       public         heap    postgres    false                    1259    99038    ShiftDetail    TABLE     "  CREATE TABLE public."ShiftDetail" (
    "ShiftDetailId" integer NOT NULL,
    "ShiftId" integer NOT NULL,
    "ShiftDate" timestamp without time zone NOT NULL,
    "RegionId" integer,
    "StartTime" time without time zone NOT NULL,
    "EndTime" time without time zone NOT NULL,
    "Status" smallint NOT NULL,
    "IsDeleted" bit(1) NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "LastRunningDate" timestamp without time zone,
    "EventId" character varying(100),
    "IsSync" bit(1)
);
 !   DROP TABLE public."ShiftDetail";
       public         heap    postgres    false                    1259    99041    ShiftDetailRegion    TABLE     �   CREATE TABLE public."ShiftDetailRegion" (
    "ShiftDetailRegionId" integer NOT NULL,
    "ShiftDetailId" integer NOT NULL,
    "RegionId" integer NOT NULL,
    "IsDeleted" bit(1)
);
 '   DROP TABLE public."ShiftDetailRegion";
       public         heap    postgres    false                    1259    99044 )   ShiftDetailRegion_ShiftDetailRegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 B   DROP SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq";
       public          postgres    false    278         �           0    0 )   ShiftDetailRegion_ShiftDetailRegionId_seq    SEQUENCE OWNED BY     }   ALTER SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq" OWNED BY public."ShiftDetailRegion"."ShiftDetailRegionId";
          public          postgres    false    279                    1259    99045    ShiftDetail_ShiftDetailId_seq    SEQUENCE     �   CREATE SEQUENCE public."ShiftDetail_ShiftDetailId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public."ShiftDetail_ShiftDetailId_seq";
       public          postgres    false    277         �           0    0    ShiftDetail_ShiftDetailId_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public."ShiftDetail_ShiftDetailId_seq" OWNED BY public."ShiftDetail"."ShiftDetailId";
          public          postgres    false    280                    1259    99046    Shift_ShiftId_seq    SEQUENCE     �   CREATE SEQUENCE public."Shift_ShiftId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."Shift_ShiftId_seq";
       public          postgres    false    276         �           0    0    Shift_ShiftId_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."Shift_ShiftId_seq" OWNED BY public."Shift"."ShiftId";
          public          postgres    false    281                    1259    99047    User    TABLE     W  CREATE TABLE public."User" (
    "UserId" integer NOT NULL,
    "AspNetUserId" character varying(128),
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "IsMobile" bit(1),
    "Street" character varying(100),
    "City" character varying(100),
    "State" character varying(100),
    "RegionId" integer,
    "ZipCode" character varying(10),
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" bit(1),
    "IP" character varying(20),
    "IsRequestWithEmail" bit(1)
);
    DROP TABLE public."User";
       public         heap    postgres    false                    1259    99052    User_UserId_seq    SEQUENCE     �   ALTER TABLE public."User" ALTER COLUMN "UserId" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."User_UserId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    282         �           2604    99468    Admin AdminId    DEFAULT     t   ALTER TABLE ONLY public."Admin" ALTER COLUMN "AdminId" SET DEFAULT nextval('public."Admin_AdminId_seq"'::regclass);
 @   ALTER TABLE public."Admin" ALTER COLUMN "AdminId" DROP DEFAULT;
       public          postgres    false    218    215         �           2604    99469    AdminRegion AdminRegionId    DEFAULT     �   ALTER TABLE ONLY public."AdminRegion" ALTER COLUMN "AdminRegionId" SET DEFAULT nextval('public."AdminRegion_AdminRegionId_seq"'::regclass);
 L   ALTER TABLE public."AdminRegion" ALTER COLUMN "AdminRegionId" DROP DEFAULT;
       public          postgres    false    217    216         �           2604    99470    BlockRequests BlockRequestId    DEFAULT     �   ALTER TABLE ONLY public."BlockRequests" ALTER COLUMN "BlockRequestId" SET DEFAULT nextval('public."BlockRequests_BlockRequestId_seq"'::regclass);
 O   ALTER TABLE public."BlockRequests" ALTER COLUMN "BlockRequestId" DROP DEFAULT;
       public          postgres    false    223    222                     2604    99471    Business BusinessId    DEFAULT     �   ALTER TABLE ONLY public."Business" ALTER COLUMN "BusinessId" SET DEFAULT nextval('public."Business_BusinessId_seq"'::regclass);
 F   ALTER TABLE public."Business" ALTER COLUMN "BusinessId" DROP DEFAULT;
       public          postgres    false    225    224                    2604    99472    CaseTag CaseTagId    DEFAULT     |   ALTER TABLE ONLY public."CaseTag" ALTER COLUMN "CaseTagId" SET DEFAULT nextval('public."CaseTag_CaseTagId_seq"'::regclass);
 D   ALTER TABLE public."CaseTag" ALTER COLUMN "CaseTagId" DROP DEFAULT;
       public          postgres    false    227    226                    2604    99473    Concierge ConciergeId    DEFAULT     �   ALTER TABLE ONLY public."Concierge" ALTER COLUMN "ConciergeId" SET DEFAULT nextval('public."Concierge_ConciergeId_seq"'::regclass);
 H   ALTER TABLE public."Concierge" ALTER COLUMN "ConciergeId" DROP DEFAULT;
       public          postgres    false    229    228                    2604    99474    EncounterForm EncounterFormId    DEFAULT     �   ALTER TABLE ONLY public."EncounterForm" ALTER COLUMN "EncounterFormId" SET DEFAULT nextval('public."EncounterForm_EncounterFormId_seq"'::regclass);
 P   ALTER TABLE public."EncounterForm" ALTER COLUMN "EncounterFormId" DROP DEFAULT;
       public          postgres    false    233    232                    2604    99475 +   HealthProfessionalType HealthProfessionalId    DEFAULT     �   ALTER TABLE ONLY public."HealthProfessionalType" ALTER COLUMN "HealthProfessionalId" SET DEFAULT nextval('public."HealthProfessionalType_HealthProfessionalId_seq"'::regclass);
 ^   ALTER TABLE public."HealthProfessionalType" ALTER COLUMN "HealthProfessionalId" DROP DEFAULT;
       public          postgres    false    235    234                    2604    99476    HealthProfessionals VendorId    DEFAULT     �   ALTER TABLE ONLY public."HealthProfessionals" ALTER COLUMN "VendorId" SET DEFAULT nextval('public."HealthProfessionals_VendorId_seq"'::regclass);
 O   ALTER TABLE public."HealthProfessionals" ALTER COLUMN "VendorId" DROP DEFAULT;
       public          postgres    false    237    236                    2604    99477    Menu MenuId    DEFAULT     p   ALTER TABLE ONLY public."Menu" ALTER COLUMN "MenuId" SET DEFAULT nextval('public."Menu_MenuId_seq"'::regclass);
 >   ALTER TABLE public."Menu" ALTER COLUMN "MenuId" DROP DEFAULT;
       public          postgres    false    239    238                    2604    99478    OrderDetails Id    DEFAULT     x   ALTER TABLE ONLY public."OrderDetails" ALTER COLUMN "Id" SET DEFAULT nextval('public."OrderDetails_Id_seq"'::regclass);
 B   ALTER TABLE public."OrderDetails" ALTER COLUMN "Id" DROP DEFAULT;
       public          postgres    false    241    240         	           2604    99479    Physician PhysicianId    DEFAULT     �   ALTER TABLE ONLY public."Physician" ALTER COLUMN "PhysicianId" SET DEFAULT nextval('public."Physician_PhysicianId_seq"'::regclass);
 H   ALTER TABLE public."Physician" ALTER COLUMN "PhysicianId" DROP DEFAULT;
       public          postgres    false    249    242         
           2604    99480    PhysicianLocation LocationId    DEFAULT     �   ALTER TABLE ONLY public."PhysicianLocation" ALTER COLUMN "LocationId" SET DEFAULT nextval('public."PhysicianLocation_LocationId_seq"'::regclass);
 O   ALTER TABLE public."PhysicianLocation" ALTER COLUMN "LocationId" DROP DEFAULT;
       public          postgres    false    244    243                    2604    99481    PhysicianNotification id    DEFAULT     �   ALTER TABLE ONLY public."PhysicianNotification" ALTER COLUMN id SET DEFAULT nextval('public."PhysicianNotification_id_seq"'::regclass);
 I   ALTER TABLE public."PhysicianNotification" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    246    245                    2604    99482 !   PhysicianRegion PhysicianRegionId    DEFAULT     �   ALTER TABLE ONLY public."PhysicianRegion" ALTER COLUMN "PhysicianRegionId" SET DEFAULT nextval('public."PhysicianRegion_PhysicianRegionId_seq"'::regclass);
 T   ALTER TABLE public."PhysicianRegion" ALTER COLUMN "PhysicianRegionId" DROP DEFAULT;
       public          postgres    false    248    247                    2604    99483    Region RegionId    DEFAULT     x   ALTER TABLE ONLY public."Region" ALTER COLUMN "RegionId" SET DEFAULT nextval('public."Region_RegionId_seq"'::regclass);
 B   ALTER TABLE public."Region" ALTER COLUMN "RegionId" DROP DEFAULT;
       public          postgres    false    251    250                    2604    99484    Request RequestId    DEFAULT     |   ALTER TABLE ONLY public."Request" ALTER COLUMN "RequestId" SET DEFAULT nextval('public."Request_RequestId_seq"'::regclass);
 D   ALTER TABLE public."Request" ALTER COLUMN "RequestId" DROP DEFAULT;
       public          postgres    false    269    252                    2604    99485 !   RequestBusiness RequestBusinessId    DEFAULT     �   ALTER TABLE ONLY public."RequestBusiness" ALTER COLUMN "RequestBusinessId" SET DEFAULT nextval('public."RequestBusiness_RequestBusinessId_seq"'::regclass);
 T   ALTER TABLE public."RequestBusiness" ALTER COLUMN "RequestBusinessId" DROP DEFAULT;
       public          postgres    false    254    253                    2604    99486    RequestClient RequestClientId    DEFAULT     �   ALTER TABLE ONLY public."RequestClient" ALTER COLUMN "RequestClientId" SET DEFAULT nextval('public."RequestClient_RequestClientId_seq"'::regclass);
 P   ALTER TABLE public."RequestClient" ALTER COLUMN "RequestClientId" DROP DEFAULT;
       public          postgres    false    256    255                    2604    99487    RequestClosed RequestClosedId    DEFAULT     �   ALTER TABLE ONLY public."RequestClosed" ALTER COLUMN "RequestClosedId" SET DEFAULT nextval('public."RequestClosed_RequestClosedId_seq"'::regclass);
 P   ALTER TABLE public."RequestClosed" ALTER COLUMN "RequestClosedId" DROP DEFAULT;
       public          postgres    false    258    257                    2604    99488    RequestConcierge Id    DEFAULT     �   ALTER TABLE ONLY public."RequestConcierge" ALTER COLUMN "Id" SET DEFAULT nextval('public."RequestConcierge_Id_seq"'::regclass);
 F   ALTER TABLE public."RequestConcierge" ALTER COLUMN "Id" DROP DEFAULT;
       public          postgres    false    260    259                    2604    99489    RequestNotes RequestNotesId    DEFAULT     �   ALTER TABLE ONLY public."RequestNotes" ALTER COLUMN "RequestNotesId" SET DEFAULT nextval('public."RequestNotes_RequestNotesId_seq"'::regclass);
 N   ALTER TABLE public."RequestNotes" ALTER COLUMN "RequestNotesId" DROP DEFAULT;
       public          postgres    false    262    261                    2604    99490 #   RequestStatusLog RequestStatusLogId    DEFAULT     �   ALTER TABLE ONLY public."RequestStatusLog" ALTER COLUMN "RequestStatusLogId" SET DEFAULT nextval('public."RequestStatusLog_RequestStatusLogId_seq"'::regclass);
 V   ALTER TABLE public."RequestStatusLog" ALTER COLUMN "RequestStatusLogId" DROP DEFAULT;
       public          postgres    false    264    263                    2604    99491    RequestType RequestTypeId    DEFAULT     �   ALTER TABLE ONLY public."RequestType" ALTER COLUMN "RequestTypeId" SET DEFAULT nextval('public."RequestType_RequestTypeId_seq"'::regclass);
 L   ALTER TABLE public."RequestType" ALTER COLUMN "RequestTypeId" DROP DEFAULT;
       public          postgres    false    266    265                    2604    99492 !   RequestWiseFile RequestWiseFileID    DEFAULT     �   ALTER TABLE ONLY public."RequestWiseFile" ALTER COLUMN "RequestWiseFileID" SET DEFAULT nextval('public."RequestWiseFile_RequestWiseFileID_seq"'::regclass);
 T   ALTER TABLE public."RequestWiseFile" ALTER COLUMN "RequestWiseFileID" DROP DEFAULT;
       public          postgres    false    268    267                    2604    99493    Role RoleId    DEFAULT     p   ALTER TABLE ONLY public."Role" ALTER COLUMN "RoleId" SET DEFAULT nextval('public."Role_RoleId_seq"'::regclass);
 >   ALTER TABLE public."Role" ALTER COLUMN "RoleId" DROP DEFAULT;
       public          postgres    false    273    270                    2604    99494    RoleMenu RoleMenuId    DEFAULT     �   ALTER TABLE ONLY public."RoleMenu" ALTER COLUMN "RoleMenuId" SET DEFAULT nextval('public."RoleMenu_RoleMenuId_seq"'::regclass);
 F   ALTER TABLE public."RoleMenu" ALTER COLUMN "RoleMenuId" DROP DEFAULT;
       public          postgres    false    272    271                    2604    99495    Shift ShiftId    DEFAULT     t   ALTER TABLE ONLY public."Shift" ALTER COLUMN "ShiftId" SET DEFAULT nextval('public."Shift_ShiftId_seq"'::regclass);
 @   ALTER TABLE public."Shift" ALTER COLUMN "ShiftId" DROP DEFAULT;
       public          postgres    false    281    276                    2604    99496    ShiftDetail ShiftDetailId    DEFAULT     �   ALTER TABLE ONLY public."ShiftDetail" ALTER COLUMN "ShiftDetailId" SET DEFAULT nextval('public."ShiftDetail_ShiftDetailId_seq"'::regclass);
 L   ALTER TABLE public."ShiftDetail" ALTER COLUMN "ShiftDetailId" DROP DEFAULT;
       public          postgres    false    280    277                    2604    99497 %   ShiftDetailRegion ShiftDetailRegionId    DEFAULT     �   ALTER TABLE ONLY public."ShiftDetailRegion" ALTER COLUMN "ShiftDetailRegionId" SET DEFAULT nextval('public."ShiftDetailRegion_ShiftDetailRegionId_seq"'::regclass);
 X   ALTER TABLE public."ShiftDetailRegion" ALTER COLUMN "ShiftDetailRegionId" DROP DEFAULT;
       public          postgres    false    279    278         '          0    98870    Admin 
   TABLE DATA             COPY public."Admin" ("AdminId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "RoleId") FROM stdin;
    public          postgres    false    215       5159.dat (          0    98875    AdminRegion 
   TABLE DATA           O   COPY public."AdminRegion" ("AdminRegionId", "AdminId", "RegionId") FROM stdin;
    public          postgres    false    216       5160.dat +          0    98880    AspNetRoles 
   TABLE DATA           5   COPY public."AspNetRoles" ("Id", "Name") FROM stdin;
    public          postgres    false    219       5163.dat ,          0    98883    AspNetUserRoles 
   TABLE DATA           ?   COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
    public          postgres    false    220       5164.dat -          0    98886    AspNetUsers 
   TABLE DATA           �   COPY public."AspNetUsers" ("Id", "UserName", "PasswordHash", "Email", "PhoneNumber", "IP", "CreatedDate", "ModifiedDate") FROM stdin;
    public          postgres    false    221       5165.dat .          0    98891    BlockRequests 
   TABLE DATA           �   COPY public."BlockRequests" ("BlockRequestId", "PhoneNumber", "Email", "IsActive", "Reason", "RequestId", "IP", "CreatedDate", "ModifiedDate") FROM stdin;
    public          postgres    false    222       5166.dat 0          0    98897    Business 
   TABLE DATA           �   COPY public."Business" ("BusinessId", "Name", "Address1", "Address2", "City", "RegionId", "ZipCode", "PhoneNumber", "FaxNumber", "IsRegistered", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP") FROM stdin;
    public          postgres    false    224       5168.dat 2          0    98903    CaseTag 
   TABLE DATA           8   COPY public."CaseTag" ("CaseTagId", "Name") FROM stdin;
    public          postgres    false    226       5170.dat 4          0    98907 	   Concierge 
   TABLE DATA           �   COPY public."Concierge" ("ConciergeId", "ConciergeName", "Address", "Street", "City", "State", "ZipCode", "CreatedDate", "RegionId", "RoleId") FROM stdin;
    public          postgres    false    228       5172.dat 6          0    98911    EmailLog 
   TABLE DATA           �   COPY public."EmailLog" ("EmailLogID", "EmailTemplate", "SubjectName", "EmailID", "ConfirmationNumber", "FilePath", "RoleId", "RequestId", "AdminId", "PhysicianId", "CreateDate", "SentDate", "IsEmailSent", "SentTries", "Action") FROM stdin;
    public          postgres    false    230       5174.dat 8          0    98917    EncounterForm 
   TABLE DATA           �  COPY public."EncounterForm" ("EncounterFormId", "RequestId", "HistoryOfPresentIllnessOrInjury", "MedicalHistory", "Medications", "Allergies", "Temp", "HR", "RR", "BloodPressureSystolic", "BloodPressureDiastolic", "O2", "Pain", "Heent", "CV", "Chest", "ABD", "Extremeties", "Skin", "Neuro", "Other", "Diagnosis", "TreatmentPlan", "MedicationsDispensed", "Procedures", "FollowUp", "AdminId", "PhysicianId", "IsFinalize") FROM stdin;
    public          postgres    false    232       5176.dat :          0    98924    HealthProfessionalType 
   TABLE DATA           �   COPY public."HealthProfessionalType" ("HealthProfessionalId", "ProfessionName", "CreatedDate", "IsActive", "IsDeleted") FROM stdin;
    public          postgres    false    234       5178.dat <          0    98928    HealthProfessionals 
   TABLE DATA           �   COPY public."HealthProfessionals" ("VendorId", "VendorName", "Profession", "FaxNumber", "Address", "City", "State", "Zip", "RegionId", "CreatedDate", "ModifiedDate", "PhoneNumber", "IsDeleted", "IP", "Email", "BusinessContact") FROM stdin;
    public          postgres    false    236       5180.dat >          0    98934    Menu 
   TABLE DATA           N   COPY public."Menu" ("MenuId", "Name", "AccountType", "SortOrder") FROM stdin;
    public          postgres    false    238       5182.dat @          0    98938    OrderDetails 
   TABLE DATA           �   COPY public."OrderDetails" ("Id", "VendorId", "RequestId", "FaxNumber", "Email", "BusinessContact", "Prescription", "NoOfRefill", "CreatedDate", "CreatedBy") FROM stdin;
    public          postgres    false    240       5184.dat B          0    98944 	   Physician 
   TABLE DATA             COPY public."Physician" ("PhysicianId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "MedicalLicense", "Photo", "AdminNotes", "IsAgreementDoc", "IsBackgroundDoc", "IsTrainingDoc", "IsNonDisclosureDoc", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "BusinessName", "BusinessWebsite", "IsDeleted", "RoleId", "NPINumber", "IsLicenseDoc", "Signature", "IsCredentialDoc", "IsTokenGenerate", "SyncEmailAddress") FROM stdin;
    public          postgres    false    242       5186.dat C          0    98949    PhysicianLocation 
   TABLE DATA           �   COPY public."PhysicianLocation" ("LocationId", "PhysicianId", "Latitude", "Longitude", "CreatedDate", "PhysicianName", "Address") FROM stdin;
    public          postgres    false    243       5187.dat E          0    98955    PhysicianNotification 
   TABLE DATA           ]   COPY public."PhysicianNotification" (id, "PhysicianId", "IsNotificationStopped") FROM stdin;
    public          postgres    false    245       5189.dat G          0    98959    PhysicianRegion 
   TABLE DATA           [   COPY public."PhysicianRegion" ("PhysicianRegionId", "PhysicianId", "RegionId") FROM stdin;
    public          postgres    false    247       5191.dat J          0    98964    Region 
   TABLE DATA           F   COPY public."Region" ("RegionId", "Name", "Abbreviation") FROM stdin;
    public          postgres    false    250       5194.dat L          0    98968    Request 
   TABLE DATA           �  COPY public."Request" ("RequestId", "RequestTypeId", "UserId", "FirstName", "LastName", "PhoneNumber", "Email", "Status", "PhysicianId", "ConfirmationNumber", "CreatedDate", "IsDeleted", "ModifiedDate", "DeclinedBy", "IsUrgentEmailSent", "LastWellnessDate", "IsMobile", "CallType", "CompletedByPhysician", "LastReservationDate", "AcceptedDate", "RelationName", "CaseNumber", "IP", "CaseTag", "CaseTagPhysician", "PatientAccountId", "CreatedUserId") FROM stdin;
    public          postgres    false    252       5196.dat M          0    98975    RequestBusiness 
   TABLE DATA           a   COPY public."RequestBusiness" ("RequestBusinessId", "RequestId", "BusinessId", "IP") FROM stdin;
    public          postgres    false    253       5197.dat O          0    98979    RequestClient 
   TABLE DATA           �  COPY public."RequestClient" ("RequestClientId", "RequestId", "FirstName", "LastName", "PhoneNumber", "Location", "Address", "RegionId", "NotiMobile", "NotiEmail", "Notes", "Email", "strMonth", "intYear", "intDate", "IsMobile", "Street", "City", "State", "ZipCode", "CommunicationType", "RemindReservationCount", "RemindHouseCallCount", "IsSetFollowupSent", "IP", "IsReservationReminderSent", "Latitude", "Longitude") FROM stdin;
    public          postgres    false    255       5199.dat Q          0    98985    RequestClosed 
   TABLE DATA           �   COPY public."RequestClosed" ("RequestClosedId", "RequestId", "RequestStatusLogId", "PhyNotes", "ClientNotes", "IP") FROM stdin;
    public          postgres    false    257       5201.dat S          0    98991    RequestConcierge 
   TABLE DATA           T   COPY public."RequestConcierge" ("Id", "RequestId", "ConciergeId", "IP") FROM stdin;
    public          postgres    false    259       5203.dat U          0    98995    RequestNotes 
   TABLE DATA           �   COPY public."RequestNotes" ("RequestNotesId", "RequestId", "strMonth", "intYear", "intDate", "PhysicianNotes", "AdminNotes", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IP", "AdministrativeNotes") FROM stdin;
    public          postgres    false    261       5205.dat W          0    99001    RequestStatusLog 
   TABLE DATA           �   COPY public."RequestStatusLog" ("RequestStatusLogId", "RequestId", "Status", "PhysicianId", "AdminId", "TransToPhysicianId", "Notes", "CreatedDate", "IP", "TransToAdmin") FROM stdin;
    public          postgres    false    263       5207.dat Y          0    99007    RequestType 
   TABLE DATA           @   COPY public."RequestType" ("RequestTypeId", "Name") FROM stdin;
    public          postgres    false    265       5209.dat [          0    99011    RequestWiseFile 
   TABLE DATA           �   COPY public."RequestWiseFile" ("RequestWiseFileID", "RequestId", "FileName", "CreatedDate", "PhysicianId", "AdminId", "DocType", "IsFrontSide", "IsCompensation", "IP", "IsFinalize", "IsDeleted", "IsPatientRecords") FROM stdin;
    public          postgres    false    267       5211.dat ^          0    99019    Role 
   TABLE DATA           �   COPY public."Role" ("RoleId", "Name", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IsDeleted", "IP", "AccountType") FROM stdin;
    public          postgres    false    270       5214.dat _          0    99024    RoleMenu 
   TABLE DATA           F   COPY public."RoleMenu" ("RoleMenuId", "RoleId", "MenuId") FROM stdin;
    public          postgres    false    271       5215.dat b          0    99029    SMSLog 
   TABLE DATA           �   COPY public."SMSLog" ("SMSLogID", "SMSTemplate", "MobileNumber", "ConfirmationNumber", "RoleId", "AdminId", "RequestId", "PhysicianId", "CreateDate", "SentDate", "IsSMSSent", "SentTries", "Action") FROM stdin;
    public          postgres    false    274       5218.dat d          0    99035    Shift 
   TABLE DATA           �   COPY public."Shift" ("ShiftId", "PhysicianId", "StartDate", "IsRepeat", "WeekDays", "RepeatUpto", "CreatedBy", "CreatedDate", "IP") FROM stdin;
    public          postgres    false    276       5220.dat e          0    99038    ShiftDetail 
   TABLE DATA           �   COPY public."ShiftDetail" ("ShiftDetailId", "ShiftId", "ShiftDate", "RegionId", "StartTime", "EndTime", "Status", "IsDeleted", "ModifiedBy", "ModifiedDate", "LastRunningDate", "EventId", "IsSync") FROM stdin;
    public          postgres    false    277       5221.dat f          0    99041    ShiftDetailRegion 
   TABLE DATA           n   COPY public."ShiftDetailRegion" ("ShiftDetailRegionId", "ShiftDetailId", "RegionId", "IsDeleted") FROM stdin;
    public          postgres    false    278       5222.dat j          0    99047    User 
   TABLE DATA           3  COPY public."User" ("UserId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "IsMobile", "Street", "City", "State", "RegionId", "ZipCode", "strMonth", "intYear", "intDate", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP", "IsRequestWithEmail") FROM stdin;
    public          postgres    false    282       5226.dat �           0    0    AdminRegion_AdminRegionId_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."AdminRegion_AdminRegionId_seq"', 20, true);
          public          postgres    false    217         �           0    0    Admin_AdminId_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Admin_AdminId_seq"', 4, true);
          public          postgres    false    218         �           0    0     BlockRequests_BlockRequestId_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('public."BlockRequests_BlockRequestId_seq"', 10, true);
          public          postgres    false    223         �           0    0    Business_BusinessId_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."Business_BusinessId_seq"', 14, true);
          public          postgres    false    225         �           0    0    CaseTag_CaseTagId_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public."CaseTag_CaseTagId_seq"', 7, true);
          public          postgres    false    227         �           0    0    Concierge_ConciergeId_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public."Concierge_ConciergeId_seq"', 13, true);
          public          postgres    false    229         �           0    0    EmailLog_EmailLogID_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public."EmailLog_EmailLogID_seq"', 5, true);
          public          postgres    false    231         �           0    0 !   EncounterForm_EncounterFormId_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('public."EncounterForm_EncounterFormId_seq"', 6, true);
          public          postgres    false    233         �           0    0 /   HealthProfessionalType_HealthProfessionalId_seq    SEQUENCE SET     _   SELECT pg_catalog.setval('public."HealthProfessionalType_HealthProfessionalId_seq"', 3, true);
          public          postgres    false    235         �           0    0     HealthProfessionals_VendorId_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('public."HealthProfessionals_VendorId_seq"', 10, true);
          public          postgres    false    237         �           0    0    Menu_MenuId_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Menu_MenuId_seq"', 29, true);
          public          postgres    false    239         �           0    0    OrderDetails_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public."OrderDetails_Id_seq"', 2, true);
          public          postgres    false    241         �           0    0     PhysicianLocation_LocationId_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public."PhysicianLocation_LocationId_seq"', 3, true);
          public          postgres    false    244         �           0    0    PhysicianNotification_id_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public."PhysicianNotification_id_seq"', 23, true);
          public          postgres    false    246         �           0    0 %   PhysicianRegion_PhysicianRegionId_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('public."PhysicianRegion_PhysicianRegionId_seq"', 27, true);
          public          postgres    false    248         �           0    0    Physician_PhysicianId_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public."Physician_PhysicianId_seq"', 11, true);
          public          postgres    false    249         �           0    0    Region_RegionId_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public."Region_RegionId_seq"', 1, true);
          public          postgres    false    251         �           0    0 %   RequestBusiness_RequestBusinessId_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('public."RequestBusiness_RequestBusinessId_seq"', 1, false);
          public          postgres    false    254         �           0    0 !   RequestClient_RequestClientId_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('public."RequestClient_RequestClientId_seq"', 61, true);
          public          postgres    false    256         �           0    0 !   RequestClosed_RequestClosedId_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('public."RequestClosed_RequestClosedId_seq"', 1, false);
          public          postgres    false    258         �           0    0    RequestConcierge_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."RequestConcierge_Id_seq"', 1, false);
          public          postgres    false    260         �           0    0    RequestNotes_RequestNotesId_seq    SEQUENCE SET     O   SELECT pg_catalog.setval('public."RequestNotes_RequestNotesId_seq"', 5, true);
          public          postgres    false    262         �           0    0 '   RequestStatusLog_RequestStatusLogId_seq    SEQUENCE SET     X   SELECT pg_catalog.setval('public."RequestStatusLog_RequestStatusLogId_seq"', 76, true);
          public          postgres    false    264         �           0    0    RequestType_RequestTypeId_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."RequestType_RequestTypeId_seq"', 1, false);
          public          postgres    false    266         �           0    0 %   RequestWiseFile_RequestWiseFileID_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('public."RequestWiseFile_RequestWiseFileID_seq"', 72, true);
          public          postgres    false    268         �           0    0    Request_RequestId_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."Request_RequestId_seq"', 68, true);
          public          postgres    false    269         �           0    0    RoleMenu_RoleMenuId_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."RoleMenu_RoleMenuId_seq"', 30, true);
          public          postgres    false    272         �           0    0    Role_RoleId_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Role_RoleId_seq"', 41, true);
          public          postgres    false    273         �           0    0    SMSLog_SMSLogID_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public."SMSLog_SMSLogID_seq"', 1, false);
          public          postgres    false    275         �           0    0 )   ShiftDetailRegion_ShiftDetailRegionId_seq    SEQUENCE SET     Z   SELECT pg_catalog.setval('public."ShiftDetailRegion_ShiftDetailRegionId_seq"', 1, false);
          public          postgres    false    279         �           0    0    ShiftDetail_ShiftDetailId_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."ShiftDetail_ShiftDetailId_seq"', 38, true);
          public          postgres    false    280         �           0    0    Shift_ShiftId_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."Shift_ShiftId_seq"', 26, true);
          public          postgres    false    281         �           0    0    User_UserId_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."User_UserId_seq"', 4, true);
          public          postgres    false    283         %           2606    99084    AdminRegion AdminRegion_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "AdminRegion_pkey" PRIMARY KEY ("AdminRegionId");
 J   ALTER TABLE ONLY public."AdminRegion" DROP CONSTRAINT "AdminRegion_pkey";
       public            postgres    false    216         #           2606    99086    Admin Admin_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_pkey" PRIMARY KEY ("AdminId");
 >   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_pkey";
       public            postgres    false    215         '           2606    99088    AspNetRoles AspNetRoles_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "AspNetRoles_pkey" PRIMARY KEY ("Id");
 J   ALTER TABLE ONLY public."AspNetRoles" DROP CONSTRAINT "AspNetRoles_pkey";
       public            postgres    false    219         )           2606    99090 $   AspNetUserRoles AspNetUserRoles_pkey 
   CONSTRAINT     v   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "AspNetUserRoles_pkey" PRIMARY KEY ("UserId", "RoleId");
 R   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "AspNetUserRoles_pkey";
       public            postgres    false    220    220         +           2606    99092    AspNetUsers AspNetUsers_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "AspNetUsers_pkey" PRIMARY KEY ("Id");
 J   ALTER TABLE ONLY public."AspNetUsers" DROP CONSTRAINT "AspNetUsers_pkey";
       public            postgres    false    221         -           2606    99094     BlockRequests BlockRequests_pkey 
   CONSTRAINT     p   ALTER TABLE ONLY public."BlockRequests"
    ADD CONSTRAINT "BlockRequests_pkey" PRIMARY KEY ("BlockRequestId");
 N   ALTER TABLE ONLY public."BlockRequests" DROP CONSTRAINT "BlockRequests_pkey";
       public            postgres    false    222         /           2606    99096    Business Business_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_pkey" PRIMARY KEY ("BusinessId");
 D   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_pkey";
       public            postgres    false    224         1           2606    99098    Concierge Concierge_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public."Concierge"
    ADD CONSTRAINT "Concierge_pkey" PRIMARY KEY ("ConciergeId");
 F   ALTER TABLE ONLY public."Concierge" DROP CONSTRAINT "Concierge_pkey";
       public            postgres    false    228         3           2606    99100    EmailLog EmailLog_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."EmailLog"
    ADD CONSTRAINT "EmailLog_pkey" PRIMARY KEY ("EmailLogID");
 D   ALTER TABLE ONLY public."EmailLog" DROP CONSTRAINT "EmailLog_pkey";
       public            postgres    false    230         5           2606    99102     EncounterForm EncounterForm_pkey 
   CONSTRAINT     q   ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_pkey" PRIMARY KEY ("EncounterFormId");
 N   ALTER TABLE ONLY public."EncounterForm" DROP CONSTRAINT "EncounterForm_pkey";
       public            postgres    false    232         7           2606    99104 2   HealthProfessionalType HealthProfessionalType_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public."HealthProfessionalType"
    ADD CONSTRAINT "HealthProfessionalType_pkey" PRIMARY KEY ("HealthProfessionalId");
 `   ALTER TABLE ONLY public."HealthProfessionalType" DROP CONSTRAINT "HealthProfessionalType_pkey";
       public            postgres    false    234         9           2606    99106 ,   HealthProfessionals HealthProfessionals_pkey 
   CONSTRAINT     v   ALTER TABLE ONLY public."HealthProfessionals"
    ADD CONSTRAINT "HealthProfessionals_pkey" PRIMARY KEY ("VendorId");
 Z   ALTER TABLE ONLY public."HealthProfessionals" DROP CONSTRAINT "HealthProfessionals_pkey";
       public            postgres    false    236                    2606    99107    Menu Menu_AccountType_check    CHECK CONSTRAINT     �   ALTER TABLE public."Menu"
    ADD CONSTRAINT "Menu_AccountType_check" CHECK (("AccountType" = ANY (ARRAY[1, 2, 3, 4]))) NOT VALID;
 D   ALTER TABLE public."Menu" DROP CONSTRAINT "Menu_AccountType_check";
       public          postgres    false    238    238         ;           2606    99109    Menu Menu_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Menu"
    ADD CONSTRAINT "Menu_pkey" PRIMARY KEY ("MenuId");
 <   ALTER TABLE ONLY public."Menu" DROP CONSTRAINT "Menu_pkey";
       public            postgres    false    238         =           2606    99111    OrderDetails OrderDetails_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."OrderDetails"
    ADD CONSTRAINT "OrderDetails_pkey" PRIMARY KEY ("Id");
 L   ALTER TABLE ONLY public."OrderDetails" DROP CONSTRAINT "OrderDetails_pkey";
       public            postgres    false    240         A           2606    99113 0   PhysicianNotification PhysicianNotification_pkey 
   CONSTRAINT     r   ALTER TABLE ONLY public."PhysicianNotification"
    ADD CONSTRAINT "PhysicianNotification_pkey" PRIMARY KEY (id);
 ^   ALTER TABLE ONLY public."PhysicianNotification" DROP CONSTRAINT "PhysicianNotification_pkey";
       public            postgres    false    245         C           2606    99115 $   PhysicianRegion PhysicianRegion_pkey 
   CONSTRAINT     w   ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_pkey" PRIMARY KEY ("PhysicianRegionId");
 R   ALTER TABLE ONLY public."PhysicianRegion" DROP CONSTRAINT "PhysicianRegion_pkey";
       public            postgres    false    247         ?           2606    99117    Physician Physician_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_pkey" PRIMARY KEY ("PhysicianId");
 F   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_pkey";
       public            postgres    false    242         E           2606    99119    Region Region_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."Region"
    ADD CONSTRAINT "Region_pkey" PRIMARY KEY ("RegionId");
 @   ALTER TABLE ONLY public."Region" DROP CONSTRAINT "Region_pkey";
       public            postgres    false    250         I           2606    99121 $   RequestBusiness RequestBusiness_pkey 
   CONSTRAINT     w   ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_pkey" PRIMARY KEY ("RequestBusinessId");
 R   ALTER TABLE ONLY public."RequestBusiness" DROP CONSTRAINT "RequestBusiness_pkey";
       public            postgres    false    253         K           2606    99123     RequestClient RequestClient_pkey 
   CONSTRAINT     q   ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_pkey" PRIMARY KEY ("RequestClientId");
 N   ALTER TABLE ONLY public."RequestClient" DROP CONSTRAINT "RequestClient_pkey";
       public            postgres    false    255         M           2606    99125     RequestClosed RequestClosed_pkey 
   CONSTRAINT     q   ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_pkey" PRIMARY KEY ("RequestClosedId");
 N   ALTER TABLE ONLY public."RequestClosed" DROP CONSTRAINT "RequestClosed_pkey";
       public            postgres    false    257         O           2606    99127 &   RequestConcierge RequestConcierge_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_pkey" PRIMARY KEY ("Id");
 T   ALTER TABLE ONLY public."RequestConcierge" DROP CONSTRAINT "RequestConcierge_pkey";
       public            postgres    false    259         Q           2606    99129    RequestNotes RequestNotes_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public."RequestNotes"
    ADD CONSTRAINT "RequestNotes_pkey" PRIMARY KEY ("RequestNotesId");
 L   ALTER TABLE ONLY public."RequestNotes" DROP CONSTRAINT "RequestNotes_pkey";
       public            postgres    false    261         S           2606    99131 &   RequestStatusLog RequestStatusLog_pkey 
   CONSTRAINT     z   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_pkey" PRIMARY KEY ("RequestStatusLogId");
 T   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_pkey";
       public            postgres    false    263         U           2606    99133    RequestType RequestType_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public."RequestType"
    ADD CONSTRAINT "RequestType_pkey" PRIMARY KEY ("RequestTypeId");
 J   ALTER TABLE ONLY public."RequestType" DROP CONSTRAINT "RequestType_pkey";
       public            postgres    false    265         W           2606    99135 $   RequestWiseFile RequestWiseFile_pkey 
   CONSTRAINT     w   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_pkey" PRIMARY KEY ("RequestWiseFileID");
 R   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT "RequestWiseFile_pkey";
       public            postgres    false    267         G           2606    99137    Request Request_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_pkey" PRIMARY KEY ("RequestId");
 B   ALTER TABLE ONLY public."Request" DROP CONSTRAINT "Request_pkey";
       public            postgres    false    252         [           2606    99139    RoleMenu RoleMenu_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_pkey" PRIMARY KEY ("RoleMenuId");
 D   ALTER TABLE ONLY public."RoleMenu" DROP CONSTRAINT "RoleMenu_pkey";
       public            postgres    false    271         Y           2606    99141    Role Role_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("RoleId");
 <   ALTER TABLE ONLY public."Role" DROP CONSTRAINT "Role_pkey";
       public            postgres    false    270         ]           2606    99143    SMSLog SMSLog_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."SMSLog"
    ADD CONSTRAINT "SMSLog_pkey" PRIMARY KEY ("SMSLogID");
 @   ALTER TABLE ONLY public."SMSLog" DROP CONSTRAINT "SMSLog_pkey";
       public            postgres    false    274         c           2606    99145 (   ShiftDetailRegion ShiftDetailRegion_pkey 
   CONSTRAINT     }   ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_pkey" PRIMARY KEY ("ShiftDetailRegionId");
 V   ALTER TABLE ONLY public."ShiftDetailRegion" DROP CONSTRAINT "ShiftDetailRegion_pkey";
       public            postgres    false    278         a           2606    99147    ShiftDetail ShiftDetail_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_pkey" PRIMARY KEY ("ShiftDetailId");
 J   ALTER TABLE ONLY public."ShiftDetail" DROP CONSTRAINT "ShiftDetail_pkey";
       public            postgres    false    277         _           2606    99149    Shift Shift_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_pkey" PRIMARY KEY ("ShiftId");
 >   ALTER TABLE ONLY public."Shift" DROP CONSTRAINT "Shift_pkey";
       public            postgres    false    276         e           2606    99151    User User_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("UserId");
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    282         f           2606    99152    Admin Admin_AspNetUserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");
 K   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_AspNetUserId_fkey";
       public          postgres    false    4907    221    215         g           2606    99157    Admin Admin_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 I   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_ModifiedBy_fkey";
       public          postgres    false    4907    221    215         l           2606    99162     Business Business_CreatedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");
 N   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_CreatedBy_fkey";
       public          postgres    false    224    221    4907         m           2606    99167 !   Business Business_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 O   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_ModifiedBy_fkey";
       public          postgres    false    4907    221    224         n           2606    99172    Business Business_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 M   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_RegionId_fkey";
       public          postgres    false    4933    250    224         o           2606    99177 !   Concierge Concierge_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Concierge"
    ADD CONSTRAINT "Concierge_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 O   ALTER TABLE ONLY public."Concierge" DROP CONSTRAINT "Concierge_RegionId_fkey";
       public          postgres    false    228    4933    250         p           2606    99182 (   EncounterForm EncounterForm_AdminId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_AdminId_fkey" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");
 V   ALTER TABLE ONLY public."EncounterForm" DROP CONSTRAINT "EncounterForm_AdminId_fkey";
       public          postgres    false    215    4899    232         q           2606    99187 ,   EncounterForm EncounterForm_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 Z   ALTER TABLE ONLY public."EncounterForm" DROP CONSTRAINT "EncounterForm_PhysicianId_fkey";
       public          postgres    false    242    232    4927         r           2606    99192 *   EncounterForm EncounterForm_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 X   ALTER TABLE ONLY public."EncounterForm" DROP CONSTRAINT "EncounterForm_RequestId_fkey";
       public          postgres    false    252    232    4935         h           2606    99197 "   AdminRegion FK_AdminRegion_AdminId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "FK_AdminRegion_AdminId" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");
 P   ALTER TABLE ONLY public."AdminRegion" DROP CONSTRAINT "FK_AdminRegion_AdminId";
       public          postgres    false    4899    215    216         i           2606    99202 #   AdminRegion FK_AdminRegion_RegionId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "FK_AdminRegion_RegionId" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 Q   ALTER TABLE ONLY public."AdminRegion" DROP CONSTRAINT "FK_AdminRegion_RegionId";
       public          postgres    false    250    4933    216         s           2606    99207 7   HealthProfessionals HealthProfessionals_Profession_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."HealthProfessionals"
    ADD CONSTRAINT "HealthProfessionals_Profession_fkey" FOREIGN KEY ("Profession") REFERENCES public."HealthProfessionalType"("HealthProfessionalId");
 e   ALTER TABLE ONLY public."HealthProfessionals" DROP CONSTRAINT "HealthProfessionals_Profession_fkey";
       public          postgres    false    234    236    4919         x           2606    99212 4   PhysicianLocation PhysicianLocation_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PhysicianLocation"
    ADD CONSTRAINT "PhysicianLocation_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 b   ALTER TABLE ONLY public."PhysicianLocation" DROP CONSTRAINT "PhysicianLocation_PhysicianId_fkey";
       public          postgres    false    243    4927    242         y           2606    99217 <   PhysicianNotification PhysicianNotification_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PhysicianNotification"
    ADD CONSTRAINT "PhysicianNotification_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 j   ALTER TABLE ONLY public."PhysicianNotification" DROP CONSTRAINT "PhysicianNotification_PhysicianId_fkey";
       public          postgres    false    245    242    4927         z           2606    99222 0   PhysicianRegion PhysicianRegion_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 ^   ALTER TABLE ONLY public."PhysicianRegion" DROP CONSTRAINT "PhysicianRegion_PhysicianId_fkey";
       public          postgres    false    242    247    4927         {           2606    99227 -   PhysicianRegion PhysicianRegion_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 [   ALTER TABLE ONLY public."PhysicianRegion" DROP CONSTRAINT "PhysicianRegion_RegionId_fkey";
       public          postgres    false    4933    247    250         t           2606    99232 %   Physician Physician_AspNetUserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");
 S   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_AspNetUserId_fkey";
       public          postgres    false    242    221    4907         u           2606    99237 "   Physician Physician_CreatedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");
 P   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_CreatedBy_fkey";
       public          postgres    false    221    4907    242         v           2606    99242 #   Physician Physician_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 Q   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_ModifiedBy_fkey";
       public          postgres    false    221    4907    242         w           2606    99247    Physician Physician_RoleId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Role"("RoleId");
 M   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_RoleId_fkey";
       public          postgres    false    4953    242    270         ~           2606    99252 /   RequestBusiness RequestBusiness_BusinessId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_BusinessId_fkey" FOREIGN KEY ("BusinessId") REFERENCES public."Business"("BusinessId");
 ]   ALTER TABLE ONLY public."RequestBusiness" DROP CONSTRAINT "RequestBusiness_BusinessId_fkey";
       public          postgres    false    253    224    4911                    2606    99257 .   RequestBusiness RequestBusiness_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 \   ALTER TABLE ONLY public."RequestBusiness" DROP CONSTRAINT "RequestBusiness_RequestId_fkey";
       public          postgres    false    253    4935    252         �           2606    99262 )   RequestClient RequestClient_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 W   ALTER TABLE ONLY public."RequestClient" DROP CONSTRAINT "RequestClient_RegionId_fkey";
       public          postgres    false    4933    255    250         �           2606    99267 *   RequestClient RequestClient_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 X   ALTER TABLE ONLY public."RequestClient" DROP CONSTRAINT "RequestClient_RequestId_fkey";
       public          postgres    false    4935    252    255         �           2606    99272 *   RequestClosed RequestClosed_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 X   ALTER TABLE ONLY public."RequestClosed" DROP CONSTRAINT "RequestClosed_RequestId_fkey";
       public          postgres    false    257    4935    252         �           2606    99277 3   RequestClosed RequestClosed_RequestStatusLogId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_RequestStatusLogId_fkey" FOREIGN KEY ("RequestStatusLogId") REFERENCES public."RequestStatusLog"("RequestStatusLogId");
 a   ALTER TABLE ONLY public."RequestClosed" DROP CONSTRAINT "RequestClosed_RequestStatusLogId_fkey";
       public          postgres    false    257    263    4947         �           2606    99282 2   RequestConcierge RequestConcierge_ConciergeId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_ConciergeId_fkey" FOREIGN KEY ("ConciergeId") REFERENCES public."Concierge"("ConciergeId");
 `   ALTER TABLE ONLY public."RequestConcierge" DROP CONSTRAINT "RequestConcierge_ConciergeId_fkey";
       public          postgres    false    259    228    4913         �           2606    99287 0   RequestConcierge RequestConcierge_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 ^   ALTER TABLE ONLY public."RequestConcierge" DROP CONSTRAINT "RequestConcierge_RequestId_fkey";
       public          postgres    false    252    259    4935         �           2606    99292 (   RequestNotes RequestNotes_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestNotes"
    ADD CONSTRAINT "RequestNotes_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 V   ALTER TABLE ONLY public."RequestNotes" DROP CONSTRAINT "RequestNotes_RequestId_fkey";
       public          postgres    false    261    252    4935         �           2606    99297 .   RequestStatusLog RequestStatusLog_AdminId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_AdminId_fkey" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");
 \   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_AdminId_fkey";
       public          postgres    false    215    4899    263         �           2606    99302 2   RequestStatusLog RequestStatusLog_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 `   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_PhysicianId_fkey";
       public          postgres    false    4927    242    263         �           2606    99307 0   RequestStatusLog RequestStatusLog_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 ^   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_RequestId_fkey";
       public          postgres    false    263    4935    252         �           2606    99312 9   RequestStatusLog RequestStatusLog_TransToPhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_TransToPhysicianId_fkey" FOREIGN KEY ("TransToPhysicianId") REFERENCES public."Physician"("PhysicianId");
 g   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_TransToPhysicianId_fkey";
       public          postgres    false    263    4927    242         �           2606    99317 ,   RequestWiseFile RequestWiseFile_AdminId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_AdminId_fkey" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");
 Z   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT "RequestWiseFile_AdminId_fkey";
       public          postgres    false    267    4899    215         �           2606    99322 0   RequestWiseFile RequestWiseFile_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 ^   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT "RequestWiseFile_PhysicianId_fkey";
       public          postgres    false    267    242    4927         �           2606    99327 .   RequestWiseFile RequestWiseFile_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 \   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT "RequestWiseFile_RequestId_fkey";
       public          postgres    false    4935    252    267         |           2606    99332     Request Request_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 N   ALTER TABLE ONLY public."Request" DROP CONSTRAINT "Request_PhysicianId_fkey";
       public          postgres    false    4927    242    252         }           2606    99337    Request Request_UserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."User"("UserId");
 I   ALTER TABLE ONLY public."Request" DROP CONSTRAINT "Request_UserId_fkey";
       public          postgres    false    282    4965    252         �           2606    99342    RoleMenu RoleMenu_MenuId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_MenuId_fkey" FOREIGN KEY ("MenuId") REFERENCES public."Menu"("MenuId");
 K   ALTER TABLE ONLY public."RoleMenu" DROP CONSTRAINT "RoleMenu_MenuId_fkey";
       public          postgres    false    238    271    4923         �           2606    99347    RoleMenu RoleMenu_RoleId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Role"("RoleId");
 K   ALTER TABLE ONLY public."RoleMenu" DROP CONSTRAINT "RoleMenu_RoleId_fkey";
       public          postgres    false    270    271    4953         �           2606    99352 1   ShiftDetailRegion ShiftDetailRegion_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 _   ALTER TABLE ONLY public."ShiftDetailRegion" DROP CONSTRAINT "ShiftDetailRegion_RegionId_fkey";
       public          postgres    false    250    278    4933         �           2606    99357 6   ShiftDetailRegion ShiftDetailRegion_ShiftDetailId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_ShiftDetailId_fkey" FOREIGN KEY ("ShiftDetailId") REFERENCES public."ShiftDetail"("ShiftDetailId");
 d   ALTER TABLE ONLY public."ShiftDetailRegion" DROP CONSTRAINT "ShiftDetailRegion_ShiftDetailId_fkey";
       public          postgres    false    277    278    4961         �           2606    99362 '   ShiftDetail ShiftDetail_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 U   ALTER TABLE ONLY public."ShiftDetail" DROP CONSTRAINT "ShiftDetail_ModifiedBy_fkey";
       public          postgres    false    4907    277    221         �           2606    99367 %   ShiftDetail ShiftDetail_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId") NOT VALID;
 S   ALTER TABLE ONLY public."ShiftDetail" DROP CONSTRAINT "ShiftDetail_RegionId_fkey";
       public          postgres    false    4933    250    277         �           2606    99372 $   ShiftDetail ShiftDetail_ShiftId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_ShiftId_fkey" FOREIGN KEY ("ShiftId") REFERENCES public."Shift"("ShiftId");
 R   ALTER TABLE ONLY public."ShiftDetail" DROP CONSTRAINT "ShiftDetail_ShiftId_fkey";
       public          postgres    false    276    277    4959         �           2606    99377    Shift Shift_CreatedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");
 H   ALTER TABLE ONLY public."Shift" DROP CONSTRAINT "Shift_CreatedBy_fkey";
       public          postgres    false    221    276    4907         �           2606    99382    Shift Shift_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 J   ALTER TABLE ONLY public."Shift" DROP CONSTRAINT "Shift_PhysicianId_fkey";
       public          postgres    false    4927    276    242         �           2606    99387    User User_AspNetUserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");
 I   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_AspNetUserId_fkey";
       public          postgres    false    4907    282    221         j           2606    99392 ,   AspNetUserRoles fk_aspnetuserrole_aspnetuser    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT fk_aspnetuserrole_aspnetuser FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id");
 X   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT fk_aspnetuserrole_aspnetuser;
       public          postgres    false    4907    221    220         k           2606    99397 &   AspNetUserRoles fk_aspnetuserrole_role    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT fk_aspnetuserrole_role FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id");
 R   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT fk_aspnetuserrole_role;
       public          postgres    false    4903    220    219                                                                                                                                                                                5159.dat                                                                                            0000600 0004000 0002000 00000001247 14612723503 0014264 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        3	a139b6bf-6d50-4dec-b887-38541a74521a	vinit	patel	vinit22734@gmail.com	9313884034	zalod 	ahmedabad	snagar	1	389170	6353664814	a139b6bf-6d50-4dec-b887-38541a74521a	2024-03-28 12:13:34.89615	\N	\N	2	\N	46
4	6c932343-3ef3-4e8d-bd87-454eb6d0d420	admin	test	admin@gmail.com	9889988989	b2 gujrat	surat gujrat	snagar	3	343334	9789789799	6c932343-3ef3-4e8d-bd87-454eb6d0d420	2024-04-02 11:10:42.987102	\N	\N	2	\N	44
2	21c57981-a679-4b62-8eee-57c1ce429643	vinit	admindemo	demo@gmail.com	8778978974	surendranagar	gujrat	snagar	1	363636	9499445454	21c57981-a679-4b62-8eee-57c1ce429643	2024-02-09 16:32:09.912537	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-24 02:53:00.769141	2	\N	10
\.


                                                                                                                                                                                                                                                                                                                                                         5160.dat                                                                                            0000600 0004000 0002000 00000000064 14612723503 0014250 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        5	3	3
6	3	1
20	4	3
31	2	1
32	2	2
33	2	1
34	2	2
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                            5163.dat                                                                                            0000600 0004000 0002000 00000000211 14612723503 0014245 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        a859db03-ea8d-4c6b-ab13-9bbd0ed96f5b	Admin
f352aa19-76b5-4342-8364-c509077c5ab1	User
b9358139-9394-4a32-927d-87a2161880a0	Physician
\.


                                                                                                                                                                                                                                                                                                                                                                                       5164.dat                                                                                            0000600 0004000 0002000 00000002021 14612723503 0014247 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        21c57981-a679-4b62-8eee-57c1ce429643	a859db03-ea8d-4c6b-ab13-9bbd0ed96f5b
f12693e1-60c3-4917-8e1c-34955508c67a	b9358139-9394-4a32-927d-87a2161880a0
5d2e6b2d-bd70-4f99-ae34-6cbe2dfe9a9a	f352aa19-76b5-4342-8364-c509077c5ab1
73871734-e442-460e-ad59-c6ff100f6826	b9358139-9394-4a32-927d-87a2161880a0
e5d6dbb2-d57b-4bcf-88eb-f220a508ffa6	b9358139-9394-4a32-927d-87a2161880a0
d09876b6-0b9d-46d4-8450-f3e6e4a5291f	b9358139-9394-4a32-927d-87a2161880a0
d760793e-a336-44b8-8f5c-27a7be2d8f52	b9358139-9394-4a32-927d-87a2161880a0
a139b6bf-6d50-4dec-b887-38541a74521a	a859db03-ea8d-4c6b-ab13-9bbd0ed96f5b
93326f49-a6bb-485e-9bd1-64739a058fbb	b9358139-9394-4a32-927d-87a2161880a0
6c932343-3ef3-4e8d-bd87-454eb6d0d420	a859db03-ea8d-4c6b-ab13-9bbd0ed96f5b
d43e6917-e0cf-4b73-8454-430f1d2dc69d	b9358139-9394-4a32-927d-87a2161880a0
06727f3e-2c09-4fc2-bc57-8da2dee6af82	b9358139-9394-4a32-927d-87a2161880a0
c4d966a5-310d-4ba7-babb-65547f543ec6	b9358139-9394-4a32-927d-87a2161880a0
5b8b641b-0ed0-4599-a1e8-c2d226079a7b	f352aa19-76b5-4342-8364-c509077c5ab1
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               5165.dat                                                                                            0000600 0004000 0002000 00000004731 14612723503 0014262 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        f12693e1-60c3-4917-8e1c-34955508c67a	first last2	xyz	a@gmail.com	787833378	12.12.21	2024-02-01 00:00:00	2024-04-19 13:59:25.957358
93326f49-a6bb-485e-9bd1-64739a058fbb	changeusername2	parthhash123	parth123@gmail.com	967967877	\N	2024-03-29 14:23:58.482122	2024-03-29 18:04:14.48611
6c932343-3ef3-4e8d-bd87-454eb6d0d420	admin123	adminhash123	admin@gmail.com	9889988989	\N	2024-04-02 11:10:39.477356	\N
d43e6917-e0cf-4b73-8454-430f1d2dc69d	newphysician	physicianhash123	sumit@gmail.com	9769667234	\N	2024-04-09 12:42:09.310677	\N
d09876b6-0b9d-46d4-8450-f3e6e4a5291f	testusername23	hash12333	sandip123@gmail.com	22435342344	\N	2024-03-27 18:12:13.706361	\N
a86d721c-b1e0-4284-a5c1-7e5a7ffd6b87	asdfa asdsadsa	d382efe5372f26c277a95222feb38818	nikul123@gmail.com	8346787687	\N	2024-04-21 15:44:38.100817	\N
7ffa72f6-546f-4c1b-aa25-56e7f1261a2a	demotest demotesting	3de6626405ecec56be46e8ba1d3f8c84	demo123@gmail.com	9999967897	\N	2024-04-23 23:08:50.078555	\N
73871734-e442-460e-ad59-c6ff100f6826	testusernamenew	hash123	ps@gmail.com	786778877	\N	2024-03-27 17:28:34.009166	\N
06727f3e-2c09-4fc2-bc57-8da2dee6af82	testusername	1e474e97346711e4f55fb2e8883aab37	jaydeep123@gmail.com	9586657856	\N	2024-04-22 01:10:14.145352	2024-04-24 02:03:49.254039
21c57981-a679-4b62-8eee-57c1ce429643	vinit admindemo	21d9029080bf2a99b0ab9c913fa9b548	demo@gmail.com	8778978974	\N	2024-02-15 12:29:39.233245	2024-04-24 09:41:00.491696
5d2e6b2d-bd70-4f99-ae34-6cbe2dfe9a9a	tatvasoftnewsoft	21d9029080bf2a99b0ab9c913fa9b548	x@gmail.com	9584959854	\N	2024-02-09 16:32:09.912537	2024-04-20 17:42:03.714385
a139b6bf-6d50-4dec-b887-38541a74521a	Adminvinit	21d9029080bf2a99b0ab9c913fa9b548	vinit22734@gmail.com	9313884034	\N	2024-03-28 12:13:21.290838	\N
2784cd86-9433-4e5e-8889-60ef80690b79	jaydeeptest	21d9029080bf2a99b0ab9c913fa9b548	jaydeep1234@gmail.com	9566766534	\N	2024-04-21 17:52:45.716951	\N
c4d966a5-310d-4ba7-babb-65547f543ec6	vinitmehta	21d9029080bf2a99b0ab9c913fa9b548	mehtavinit51@gmail.com	9898989898	\N	2024-04-25 17:07:02.343861	2024-04-25 17:10:34.292603
e5d6dbb2-d57b-4bcf-88eb-f220a508ffa6	testusername2	hash1232	raj123@gmail.com	6755676756	\N	2024-03-27 17:40:23.269369	2024-04-25 18:46:36.049134
d760793e-a336-44b8-8f5c-27a7be2d8f52	vinit patel	21d9029080bf2a99b0ab9c913fa9b548	vinit2273@gmail.com	9313884034	\N	2024-03-28 10:04:18.858591	2024-04-26 14:10:58.12044
5b8b641b-0ed0-4599-a1e8-c2d226079a7b	saurav patel	21d9029080bf2a99b0ab9c913fa9b548	aniyariyavijay441@gmail.com	9898989989	\N	2024-04-26 14:48:37.614434	\N
\.


                                       5166.dat                                                                                            0000600 0004000 0002000 00000002212 14612723503 0014253 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	1241421414	x@gmail.com	1	block by admin	32	\N	2024-03-01 14:51:44.016133	2024-04-23 23:27:38.843324
5	1241421414	x@gmail.com	1	cost issues	45	\N	2024-03-18 18:13:14.546601	2024-04-23 23:27:41.143842
6	98089089	x@gmail.com	1	payment issues	47	\N	2024-04-01 11:55:13.562579	2024-04-23 23:27:42.266908
3	1241421414	x@gmail.com	1	dsa	12	\N	2024-03-01 14:54:55.634688	2024-04-23 23:27:43.362582
4	1241421414	x@gmail.com	1	cost issues	12	\N	2024-03-06 09:26:34.243557	2024-04-23 23:27:44.617031
9	879898899789	x@gmail.com	1	cost issues	39	\N	2024-04-11 10:34:59.268352	2024-04-23 23:27:48.818718
12	1241421414	x@gmail.com	0	testreason	12	\N	2024-04-25 13:48:00.270503	\N
13	978898888	testing@gmail.com	0	reason	62	\N	2024-04-25 14:35:11.946267	\N
8	1241421414	x@gmail.com	1	unavailable	43	\N	2024-04-08 12:35:39.845993	2024-04-25 14:35:20.811281
7	978989833	x@gmail.com	1	no reply to text	57	\N	2024-04-08 12:25:02.147043	2024-04-25 14:35:21.665914
10	879898899789	x@gmail.com	1	there is cost  issuses	39	\N	2024-04-12 13:55:23.495066	2024-04-25 14:35:27.321794
11	1241421414	x@gmail.com	1	testreason	12	\N	2024-04-23 23:18:24.021351	2024-04-25 14:35:27.872685
\.


                                                                                                                                                                                                                                                                                                                                                                                      5168.dat                                                                                            0000600 0004000 0002000 00000002521 14612723503 0014260 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	vijay vijay	\N	\N	\N	1	\N	1233313	\N	\N	\N	2024-02-12 14:55:11.567339	\N	\N	\N	\N	\N
2	tatva soft	\N	\N	\N	1	\N	1231323	\N	\N	\N	2024-02-12 16:41:30.108088	\N	\N	\N	\N	\N
3	test test	\N	\N	\N	1	\N	12312312	\N	\N	\N	2024-02-12 17:21:27.415103	\N	\N	\N	\N	\N
4	abc abc	\N	\N	\N	1	\N	32312312	\N	\N	\N	2024-02-14 09:18:19.246032	\N	\N	\N	\N	\N
5	first last	\N	\N	\N	1	\N	1241421414	\N	\N	\N	2024-03-01 14:42:22.385226	\N	\N	\N	\N	\N
6	jenis j	\N	\N	\N	1	\N	1241421414	\N	\N	\N	2024-03-04 11:09:06.896446	\N	\N	\N	\N	\N
7	business business	\N	\N	\N	1	\N	8989989898	\N	\N	\N	2024-03-06 09:25:51.615787	\N	\N	\N	\N	\N
8	ad asd	\N	\N	\N	1	\N	1241421414	\N	\N	\N	2024-03-07 15:33:08.402321	\N	\N	\N	\N	\N
9	clash clan	\N	\N	\N	1	\N	1241421414	\N	\N	\N	2024-03-07 15:33:44.206768	\N	\N	\N	\N	\N
10	sfsdfs sdfsfsd	\N	\N	\N	1	\N	98089089	\N	\N	\N	2024-03-07 15:35:48.128924	\N	\N	\N	\N	\N
11	sdsfdsdf sdfsdfsd	\N	\N	\N	1	\N	89890898	\N	\N	\N	2024-03-07 15:36:12.122038	\N	\N	\N	\N	\N
12	jenis jenis	\N	\N	\N	1	\N	789899989	\N	\N	\N	2024-03-11 09:15:26.764361	\N	\N	\N	\N	\N
13	raj patel	\N	\N	\N	1	\N	9777876767	\N	\N	\N	2024-03-15 12:22:19.987631	\N	\N	\N	\N	\N
14	asdasd asaddsadsa	\N	\N	\N	1	\N	978898888	\N	\N	\N	2024-03-15 12:23:29.271109	\N	\N	\N	\N	\N
15	firstbusiness lastbusiness	\N	\N	\N	1	\N	9875485794	\N	\N	\N	2024-04-21 20:25:10.847205	\N	\N	\N	\N	\N
\.


                                                                                                                                                                               5170.dat                                                                                            0000600 0004000 0002000 00000000563 14612723503 0014255 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	No Respone to call or text, left message
2	Cost Issue
3	Insurance Issue
4	Out of Service Area
5	Not appropriate for service
6	Referral to Clinic or Hospital
7	these are the options
1	No Respone to call or text, left message
2	Cost Issue
3	Insurance Issue
4	Out of Service Area
5	Not appropriate for service
6	Referral to Clinic or Hospital
7	these are the options
\.


                                                                                                                                             5172.dat                                                                                            0000600 0004000 0002000 00000001666 14612723503 0014264 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	wwerwrwrw rwrwr	\N	vd	sdfs	ggg	12	2024-02-12 12:04:19.771328	1	\N
3	anil anil	\N	fghfh	hj	asdad	43432	2024-03-04 11:07:55.962217	1	\N
4	first cd	\N	fghfh	hj	gujrat	43432	2024-03-06 09:24:59.091049	1	\N
5	coc clan	\N	fghfh	hj	asd	43432	2024-03-07 15:32:45.617676	1	\N
6	concierge name	\N	fghfh	hj	sada	43432	2024-03-07 15:34:31.604347	1	\N
7	asdada asdadad	\N	fghfh	hj	fjfgj	43432	2024-03-07 15:35:25.33431	1	\N
8	dfgdfgd gdgdfg	\N	fghfh	hj	gujrat	43432	2024-03-07 15:36:32.782042	1	\N
9	raj raj	\N	b2	surat	gujrat	385667	2024-03-14 09:44:05.947615	1	\N
10	raj raj	\N	b2	surat	gujrat	385667	2024-03-14 09:50:17.644135	1	\N
11	raj raj	\N	b2	surat	gujrat	385667	2024-03-14 09:52:26.760351	1	\N
12	manthan patel	\N	b2	surat	gujrat	385667	2024-03-15 12:21:15.824649	1	\N
13	dipesh gohil	\N	b2	snagar	gujrat	385667	2024-04-12 14:12:34.491452	1	\N
15	raj patel	k2, surat snagar 2 343424	k2, surat	snagar	snagar	343424	2024-04-21 20:04:55.428946	2	\N
\.


                                                                          5174.dat                                                                                            0000600 0004000 0002000 00000001301 14612723503 0014250 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	https://localhost:7208/Patient/CreatePatientAccount/	Create Your Account	jaydeep123@gmail.com	SU210424SAJE0003	\N	\N	79	\N	\N	2024-04-21 17:28:27.402433	2024-04-21 17:28:27.417082	1	1	\N
3	https://localhost:7208/Patient/CreatePatientAccount/	Create Your Account	rohit123@gmail.com	SU210424SAJE0002	\N	\N	12	\N	\N	2024-04-21 17:28:27.402433	2024-04-21 17:28:27.402433	1	1	\N
4	https://localhost:7208/Patient/CreatePatientAccount/	Agreeemtnt	testing@gmail.com	\N	\N	\N	10	\N	\N	2024-04-25 15:04:59.02232	2024-04-25 15:04:59.022387	1	1	\N
5	https://localhost:7208/Patient/CreatePatientAccount/	Agreeemtnt	testing@gmail.com	\N	\N	\N	10	\N	\N	2024-04-26 16:30:32.55731	2024-04-26 16:30:32.557366	1	1	\N
\.


                                                                                                                                                                                                                                                                                                                               5176.dat                                                                                            0000600 0004000 0002000 00000003307 14612723503 0014262 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	25	test1	test2	test3	test4	test5	test6	test7	test8	test9	test10	test11	test12	test13	test14	test15	test16	test17	test18	test19	test20	test21	test22	test23	test24	\N	\N	f
2	13	injury	test medical history	test medications	test allergies	test temp	test hr	test rr	test blood pressure	test blood pressure1	test o2	test pain	test heent	test cv	test chest	test abd	test extr	test skin	tet neuro	test other	test diagnosis	test treatment plan	test medication disposed	test procedures	test follow-up	\N	\N	f
5	11	test injury	addsadads	dsadsdadsd	asdasdasda	dadad	asdasdas	dadadada	dasdasd	asdasdas	dasdad	adad	sdasdasd	asdas	dasdasd	asdasdsadasd	sdadsdas	dsasd	asdasdasd	asdasda	sdadasd	asdaadasd	adasdasd	dasdd	asdasd	\N	\N	f
6	29	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	f
7	45	test illness 	test medical history	test medications	test allergies	test temp	test hr	test rr	test blood pressure	test blood pressure1	test o2	test pain	test heent	test cv	test chest	test abd	test extr	test skin	test neuro	\N	test diagnosis	\N	\N	\N	\N	\N	7	f
8	46	test illness	test history	test medicationms	test allergies	test temp	test hr	test rr	test blood pressure	test blood pressure1	test o2	test pain	test heent	test cv	test chest	test abd	test extrq	test skin	test neuro	\N	test diagnosis	\N	test dispensed	\N	\N	\N	7	t
9	44	sad	dasd	asd	asdaas	asd	asd	asd	dasd	asdas	asd	asd	asd	asd	asd	asd	asd	asd	asd	asd	asd	asd	\N	asd	\N	\N	7	t
10	55	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	asd	asd	asd	asd	\N	7	t
11	56	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	stdf	sdfs	sdfsdf	sdfss	\N	7	t
12	20	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	wefew	wef	rf	wefwsef	2	\N	f
\.


                                                                                                                                                                                                                                                                                                                         5178.dat                                                                                            0000600 0004000 0002000 00000000213 14612723503 0014255 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	Homeopathy	2024-03-07 17:00:00.722323	\N	\N
2	Radiology	2024-03-07 17:00:00.722323	\N	\N
3	dentist	2024-03-07 17:00:00.722323	\N	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                     5180.dat                                                                                            0000600 0004000 0002000 00000003210 14612723503 0014246 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	test2	2	4	snagar gujrat	snagar	gujrat	335645	2	2024-03-07 17:10:00.722323	\N	9545453434	1	\N	vinit123@gmail.com	8987977778
4	test4	1	9	rajkot gujrat	rajkot	gujrat	397897	1	2024-03-11 17:10:00.722323	\N	9453535434	1	\N	tests@gmail.com	9878979797
3	test3	1	5	surat gujrat	surat	gujrat	364742	1	2024-03-07 17:10:00.722323	\N	9657473434	1	\N	vijay123@gmail.com	8987989789
1	test1	3	7	rajkot gujrat	rajkot	gujrat	353455	3	2024-03-07 17:10:00.722323	\N	9769797974	1	\N	anil123@gmail.com	7887978934
8	 Body Wellness	1	128	k4, snagar ahmdabad gujrat	ahmdabad	gujrat	385667	\N	2024-04-04 13:42:58.801347	2024-04-04 13:44:41.819473	967856554	1	\N	Wellness@gmail.com	967855754
6	test1business	2	124	k2, snagar ahmdabad gujrat	ahmdabad	gujrat	385667	\N	2024-04-04 10:15:28.606318	\N	9797797934	1	\N	business123@gmail.com	9796797934
10	test3business	2	123	b2 surat gujrat	surat	gujrat	385667	\N	2024-04-12 16:16:04.248347	\N	9313592437	1	\N	business3@gmail.com	967855754
7	finance	2	123	k4, snagar snagar gujrat	snagar	gujrat	385667	\N	2024-04-04 12:22:11.6657	2024-04-04 12:23:49.525761	9676797534	1	\N	finance@gmail.com	9768676534
9	radiology	2	344	b2 surat gujrat	surat	gujrat	385667	\N	2024-04-10 13:50:25.514231	\N	967679769	1	\N	yash@gmail.com	967855754
5	testbusiness	2	123	k2, surat surat gujrat	surat	gujrat	385667	\N	2024-04-04 10:09:30.091776	\N	9789797934	1	\N	business@gmail.com	9769767634
12	edsasd	2	7	k2, surat snagar gujrat	snagar	gujrat	343424	\N	2024-04-24 04:29:22.808056	\N	9825393233	\N	\N	sd@gmail.com	9854348934
11	test3business	1	123	b2 surat gujrat	surat	gujrat	385667	\N	2024-04-15 14:56:31.017563	\N	9313592437	1	\N	test3business@gmail.com	967855754
\.


                                                                                                                                                                                                                                                                                                                                                                                        5182.dat                                                                                            0000600 0004000 0002000 00000001527 14612723503 0014261 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        23	MySchedule	2	\N
16	PatientDashboard	3	\N
17	PatientProfile	3	\N
18	PatientDocuments	3	\N
19	RequestForMe	3	\N
20	RequestForSomeone	3	\N
21	AdminDashboard	1	\N
22	Location	1	\N
24	MyProfile	1	\N
25	SendOrders	1	\N
30	UserAccess	1	\N
31	Access	1	\N
32	Providers	1	\N
34	Partners	1	\N
35	CreateAdmin	1	\N
36	CreateProvider	1	\N
37	Schedulling	1	\N
39	BlockHistory	1	\N
40	SMSLogs	1	\N
41	EmailLogs	1	\N
42	SearchRecords	1	\N
43	ViewUploads	1	\N
44	ViewNotes	1	\N
45	ViewCase	1	\N
28	ProviderDashboard	2	\N
29	ProviderMyProfile	2	\N
48	ConcludeCare	2	\N
38	PatientHistory	1	\N
52	ViewUploads	2	\N
53	ViewNotes	2	\N
54	ViewCase	2	\N
55	Encounter	2	\N
56	SendOrders	2	\N
58	AddBusiness	1	\N
59	CloseCase	1	\N
60	MdOnCall	1	\N
61	RequestedShifts	1	\N
63	SendOrders	1	\N
62	CreateAccess	1	\N
64	Encounter	1	\N
65	EditPhysician	1	\N
57	PatientRecords	1	\N
\.


                                                                                                                                                                         5184.dat                                                                                            0000600 0004000 0002000 00000000410 14612723503 0014251 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	3	13	5	vijay123@gmail.com	8987989789	2 capsule	\N	2024-03-08 10:45:40.454922	\N
2	2	11	4	vinit1234@gmail.com	8987977778	3 capsule, 3 paracetamol	2	2024-03-08 10:50:25.372699	\N
3	6	22	124	business123@gmail.com	9796797934	asd	2	2024-04-24 09:46:56.702653	\N
\.


                                                                                                                                                                                                                                                        5186.dat                                                                                            0000600 0004000 0002000 00000007437 14612723503 0014273 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        4	73871734-e442-460e-ad59-c6ff100f6826	sandip	patel	ps@gmail.com	786778877	testlicense	Screenshot (1)_8542ec.png	test	1	0	\N	0	b2 gujrat	surat gujrat	snagar	1	343334	65756757	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-27 17:28:37.542348	\N	2024-04-26 18:31:46.551497	1	testbusiness	testweb	\N	42	344	\N	Screenshot (1)_40ca50.png	\N	\N	\N
2	f12693e1-60c3-4917-8e1c-34955508c67a	abc	xyz	b@gmail.com	767676767	Medical Doctor License	Screenshot (1)_19c2a4.png	test notes 2	\N	\N	\N	\N	d2	snagar	snagar	2	3534554	9534543434	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-01 15:10:01.912537	\N	\N	2	test3	test3	1	41	312	\N	Screenshot (1)_40ca50.png	\N	\N	sync456@gmail.com
3	f12693e1-60c3-4917-8e1c-34955508c67a	first	last	a@gmail.com	787833378	Physician Assistant License	Screenshot (1)_19c2a4.png	test notes 2	\N	\N	\N	\N	s2	amadavad	amadavad	3	3546344	9452354434	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-01 15:10:01.912537	f12693e1-60c3-4917-8e1c-34955508c67a	2024-03-26 11:44:55.129207	3	test1	test1	1	41	432	\N	Screenshot (1)_40ca50.png	\N	\N	sync789@gmail.com
5	e5d6dbb2-d57b-4bcf-88eb-f220a508ffa6	raj	patel	raj123@gmail.com	6755676756	testlicense2	Screenshot (1)_19c2a4.png	test	0	0	\N	0	b2 gujrat	surat gujrat	snagar	3	353453	45456546	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-27 17:40:30.557815	\N	2024-04-25 18:46:36.049344	1	businessname	testweb2	\N	30	342	\N	Screenshot (1)_40ca50.png	\N	\N	\N
6	d09876b6-0b9d-46d4-8450-f3e6e4a5291f	yash	patel	sandip123@gmail.com	22435342344	testlicense34	Screenshot (1)_99d76e.png	test admin notes	1	1	\N	1	b2 gujrat	surat gujrat	snagar	2	343334	5345345	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-27 18:12:18.445784	\N	2024-03-29 11:29:05.771559	2	businessname12	testweb21	1	30	344	1	1_20240321 (4)_26d3f1.xlsx	\N	\N	\N
1	f12693e1-60c3-4917-8e1c-34955508c67a	test1	test	p@gmail.com	787878778	Physician License	Screenshot (1)_19c2a4.png	test notes 1	1	1	\N	1	b2	surat	surat	1	3533455	9675745344	21c57981-a679-4b62-8eee-57c1ce429643	2024-02-26 09:51:30.912537	f12693e1-60c3-4917-8e1c-34955508c67a	2024-04-19 13:59:25.957595	2	test2	test7	1	30	321	1	Screenshot (1)_40ca50.png	\N	\N	sync123@gmail.com
7	d760793e-a336-44b8-8f5c-27a7be2d8f52	vinit	patel	vinit2273@gmail.com	9313884034	testlicense4	Screenshot (1)_b3f5f3.png	test3 admin notes	0	0	\N	0	zalod 	ahmedabad	snagar	3	389170	6353664814	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-28 10:04:31.550564	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-24 03:07:31.511988	1	sharemarket3	share.com	1	41	344	\N	Screenshot (1)_40ca50.png	\N	\N	\N
10	93326f49-a6bb-485e-9bd1-64739a058fbb	parth	patel	parth123@gmail.com	967967877	testlicense3	Screenshot (1)_19c2a4.png	test admin notes for parth	1	1	\N	1	b2 gujrat	surat gujrat	snagar	3	343334	976878787	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-29 14:24:03.638068	\N	2024-03-29 18:04:16.406826	1	sharemarket3	testweb3	1	41	344	\N	Screenshot (1)_40ca50.png	\N	\N	\N
11	d43e6917-e0cf-4b73-8454-430f1d2dc69d	sumit	patel	sumit@gmail.com	9769667234	testlicense4	7774236_3736765_021d2e.jpg	test admin notes	1	1	\N	1	b2 gujrat	surat gujrat	surat	3	343334	9678756334	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 12:42:16.614195	\N	\N	2	sharemarket4	testweb4	1	42	344	\N	\N	\N	\N	\N
12	06727f3e-2c09-4fc2-bc57-8da2dee6af82	jaydeep	test	jaydeep123@gmail.com	9586657856	test	SIGN HB_0be8bd.jpg	testadminnotes	1	1	\N	1	Rajkot	Rajkot	Rajkot	3	348947	9678698569	06727f3e-2c09-4fc2-bc57-8da2dee6af82	2024-04-22 01:10:35.714253	\N	\N	2	testbusinessname	testwebsite	\N	42	344	1	\N	\N	\N	\N
13	c4d966a5-310d-4ba7-babb-65547f543ec6	vinit	mehta	mehtavinit51@gmail.com	9898989898	testlicense3	Screenshot (1)_1e02d7.png	test	1	1	\N	1	Rajkot	Rajkot	Rajkot	1	343334	8989898889	c4d966a5-310d-4ba7-babb-65547f543ec6	2024-04-25 17:07:02.417874	\N	2024-04-25 17:10:34.292605	2	sharemarket3	testweb3	\N	41	344	1	Screenshot (1)_26ff04.png	\N	\N	\N
\.


                                                                                                                                                                                                                                 5187.dat                                                                                            0000600 0004000 0002000 00000000457 14612723503 0014267 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	10	21.17000000	72.83100000	\N	\N	\N
1	2	22.30815500	70.80070500	\N	\N	\N
2	3	22.30815545	70.80070545	\N	\N	\N
3	3	22.30815500	70.80070500	\N	\N	\N
1	10	21.17000000	72.83100000	\N	\N	\N
1	2	22.30815500	70.80070500	\N	\N	\N
2	3	22.30815545	70.80070545	\N	\N	\N
3	3	22.30815500	70.80070500	\N	\N	\N
\.


                                                                                                                                                                                                                 5189.dat                                                                                            0000600 0004000 0002000 00000000126 14612723503 0014262 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        14	2	1
15	3	1
18	6	0
19	7	0
22	10	0
13	1	0
23	11	0
16	4	1
17	5	0
24	12	0
25	13	0
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                          5191.dat                                                                                            0000600 0004000 0002000 00000000161 14612723503 0014252 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        2	2	2
6	1	2
12	3	2
13	3	3
14	4	3
15	4	1
16	5	3
17	6	3
26	10	3
27	11	3
28	12	1
29	12	2
30	7	2
31	7	3
32	13	3
\.


                                                                                                                                                                                                                                                                                                                                                                                                               5194.dat                                                                                            0000600 0004000 0002000 00000000050 14612723503 0014252 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	rajkot	RJ
2	snagar	SN
3	surat	SU
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        5196.dat                                                                                            0000600 0004000 0002000 00000023331 14612723503 0014263 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        56	1	6	tirth	vinit	9878798978	x@gmail.com	5	7	rj150324viti0001	2024-03-15 11:02:03.052492	\N	2024-04-19 16:22:05.922724	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
34	1	6	ms	dhoni	77777777777	x@gmail.com	5	2	\N	2024-03-01 14:47:57.717842	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	No Respone to call or text, left message	\N	\N	\N
18	2	6	sdaad	asda	313212321	x@gmail.com	4	1	\N	2024-02-14 10:06:20.335719	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	asdas	\N	\N	\N	\N	\N	\N
19	2	6	demo	demo	12354321412	x@gmail.com	4	1	\N	2024-02-14 17:02:12.454168	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	test	\N	\N	\N	\N	\N	\N
21	3	6	tesing	testing	1241421414	x@gmail.com	5	1	\N	2024-02-15 18:49:53.625588	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
22	3	6	first	last	1241421414	x@gmail.com	6	1	\N	2024-02-16 18:25:24.253227	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
28	4	6	demo	demo	1241421414	x@gmail.com	5	1	\N	2024-02-20 11:39:47.580193	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
26	4	6	first	last	999999999	x@gmail.com	5	1	\N	2024-02-20 10:33:35.782719	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	test	\N	\N	\N	\N	\N	\N
40	3	6	first	cd	1241421414	x@gmail.com	3	2	\N	2024-03-06 09:24:59.111137	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
35	1	6	first	last	1241421414	x@gmail.com	6	2	\N	2024-03-04 10:59:50.536886	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	1	\N	\N	\N
36	2	6	vinit 	vinit	78779897	x@gmail.com	5	2	\N	2024-03-04 11:06:39.529316	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	test	\N	\N	1	\N	\N	\N
29	4	6	test	test	1241421414	x@gmail.com	3	1	\N	2024-02-21 09:36:36.852679	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	test	\N	\N	\N	\N	\N	\N
14	3	6	asdad	asdad	1241421414	x@gmail.com	5	1	\N	2024-02-14 09:38:57.391003	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
16	3	6	sdfs	dffd	1241421414	x@gmail.com	5	1	\N	2024-02-14 09:48:42.962634	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
37	3	6	anil	anil	1241421414	x@gmail.com	5	2	\N	2024-03-04 11:07:55.984909	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	1	\N	\N	\N
23	1	6	dasdas	adad	1241421414	x@gmail.com	5	1	\N	2024-02-16 19:18:04.716018	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	4	\N	\N	\N
24	1	6	adsad	aasda	1241421414	x@gmail.com	5	1	\N	2024-02-16 19:20:39.329229	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	4	\N	\N	\N
30	4	6	family	friend	777777777	x@gmail.com	10	1	\N	2024-02-23 09:26:37.653169	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	test	\N	\N	\N	\N	\N	\N
41	4	6	business	business	8989989898	x@gmail.com	5	2	\N	2024-03-06 09:25:51.651894	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	1	\N	\N	\N
5	1	9	dsfs	fsdfsf	23213131312	x@gmail.com	6	1	\N	2024-02-09 16:32:09.913104	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
33	4	6	first	last	1241421414	x@gmail.com	10	3	\N	2024-03-01 14:42:22.429967	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
25	1	6	adada	asda	1241421414	x@gmail.com	3	1	\N	2024-02-16 19:21:30.348491	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
60	4	6	manthan	patel	97667877	manthan@gmail.com	3	3	rj150324pama0005	2024-03-15 12:21:15.868471	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
54	4	6	raj	raj	787886867	x@gmail.com	5	\N	\N	2024-03-14 09:52:26.829989	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	No Respone to call or text, left message	\N	\N	\N
65	1	6	yash	patel	923453494	x@gmail.com	5	\N	rj190324paya0001	2024-03-19 16:45:41.722707	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	No Respone to call or text, left message	\N	\N	\N
50	1	6	anil	anil	1241421414	x@gmail.com	10	10	\N	2024-03-07 15:37:06.406571	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
6	1	9	rwererwrwr	wrwerr	342424	abc@gmail.com	6	1	\N	2024-02-12 11:40:02.315394	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	good	\N	\N	\N	\N	\N	\N
7	1	9	wwerwrwrw	rwrwr	42342424	abc@gmail.com	4	1	\N	2024-02-12 12:04:22.795424	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
8	1	9	vijay	vijay	1233313	a@gmail.com	6	1	\N	2024-02-12 14:55:25.847539	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
9	1	9	tatva	soft	1231323	tatvasoft@gmail.com	4	1	\N	2024-02-12 16:41:34.475893	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
17	2	9	wqea	asea	7777777777\n	x@gmail.com	5	3	\N	2024-02-14 10:02:48.505083	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	sadas	\N	\N	\N	\N	\N	\N
46	3	6	asdada	asdadad	8900890808908	x@gmail.com	8	7	\N	2024-03-07 15:35:25.335436	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
51	3	6	jenis	jenis	789899989	x@gmail.com	2	1	\N	2024-03-11 09:15:26.803806	\N	\N	\N	0	\N	\N	\N	\N	\N	2024-03-11 09:15:26.803806	\N	\N	\N	\N	\N	\N	\N
59	2	6	sandip	dabhi	977889878	sandip@gmail.com	2	6	rj150324dasa0004	2024-03-15 12:14:43.170384	\N	\N	\N	0	\N	\N	\N	\N	\N	2024-03-15 12:14:43.170384	test	\N	\N	\N	\N	\N	\N
66	1	6	dharmesh	kanzariya	979776976	x@gmail.com	2	10	rj100424kadh0001	2024-04-10 14:53:56.235901	\N	\N	\N	0	\N	\N	\N	\N	\N	2024-04-17 13:01:52.36407	\N	\N	\N	\N	\N	\N	\N
67	1	6	vatsal	vatsal	96778687	x@gmail.com	2	6	rj110424vava0001	2024-04-11 14:00:52.476422	\N	\N	\N	0	\N	\N	\N	\N	\N	2024-04-17 13:01:52.36407	\N	\N	\N	\N	\N	\N	\N
68	4	6	dipesh	gohil	9567565434	dipesh@gmail.com	2	11	rj120424godi0001	2024-04-12 14:12:34.548069	\N	\N	\N	0	\N	\N	\N	\N	\N	2024-04-17 13:01:52.36407	\N	\N	\N	\N	\N	\N	\N
48	4	6	sdsfdsdf	sdfsdfsd	89890898	x@gmail.com	10	1	\N	2024-03-07 15:36:12.122198	\N	\N	\N	0	\N	\N	\N	\N	\N	2024-03-07 15:36:12.122198	\N	\N	\N	\N	\N	\N	\N
42	3	6	coc	clan	1241421414	x@gmail.com	10	5	\N	2024-03-07 15:32:45.679859	\N	\N	\N	0	\N	\N	\N	\N	\N	2024-03-07 15:32:45.679859	\N	\N	\N	\N	\N	\N	\N
83	1	3	demotest	demotesting	9999967897	demo123@gmail.com	1	\N	SU230424DEDE0001	2024-04-23 23:08:50.524721	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
70	1	6	sandip	dabhi	9876978434	x@gmail.com	1	\N	RJ210424DASA0001	2024-04-21 14:26:01.385643	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
71	1	6	tesnew	testlast	9889843934	x@gmail.com	1	\N	SU210424TETE0002	2024-04-21 14:44:04.26818	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
44	4	6	clash	clan	1241421414	x@gmail.com	8	7	\N	2024-03-07 15:33:44.208166	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
55	2	6	vinit	vinit	234234332	x@gmail.com	8	7	\N	2024-03-14 12:10:06.530572	\N	2024-04-24 05:07:30.872757	\N	0	\N	\N	\N	\N	\N	\N	test	\N	\N	\N	\N	\N	\N
12	3	6	test	vijay	1241421414	x@gmail.com	3	2	\N	2024-02-13 15:27:15.57927	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	No Respone to call or text, left message	\N	\N	\N
32	1	6	vinit	patel	1241421414	x@gmail.com	3	11	\N	2024-03-01 14:39:49.968634	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	No Respone to call or text, left message	\N	\N	\N
49	3	6	dfgdfgd	gdgdfg	1241421414	x@gmail.com	10	7	\N	2024-03-07 15:36:32.782153	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
45	3	6	concierge	name	1241421414	x@gmail.com	3	7	\N	2024-03-07 15:34:31.604545	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	Out of Service Area	\N	\N	\N
47	4	6	sfsdfs	sdfsfsd	98089089	x@gmail.com	3	5	\N	2024-03-07 15:35:48.129635	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	Cost Issue	\N	\N	\N
11	2	9	dfsf	cd	1223344434	abc@gmail.com	9	1	\N	2024-02-13 10:44:02.108762	\N	2024-04-25 13:57:07.321835	\N	0	\N	\N	\N	\N	\N	\N	dadad	\N	\N	\N	\N	\N	\N
13	2	9	abc	abc	32312312	x@gmail.com	9	1	\N	2024-02-14 09:18:21.70157	\N	2024-04-25 13:58:28.415661	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
27	4	6	first	last	99999999	x@gmail.com	9	1	\N	2024-02-20 10:34:25.817696	\N	2024-04-25 14:02:53.820254	\N	0	\N	\N	\N	\N	\N	\N	test	\N	\N	\N	\N	\N	\N
62	3	6	asdasd	asaddsadsa	978898888	testing@gmail.com	11	\N	rj150324asas0007	2024-03-15 12:23:29.281713	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
69	1	6	ashvin	test	9679767934	x@gmail.com	1	2	rj170424teas0001	2024-04-17 13:01:52.36407	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
57	1	6	parth	patel	978989833	x@gmail.com	1	\N	rj150324papa0002	2024-03-15 11:12:40.699907	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	Out of Service Area	\N	\N	\N
38	4	6	jenis	j	1241421414	x@gmail.com	5	2	\N	2024-03-04 11:09:06.932065	1	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	1	\N	\N	\N
58	1	6	yash	variya	879789879	x@gmail.com	10	2	rj150324vaya0003	2024-03-15 11:24:01.33702	\N	\N	\N	0	\N	\N	\N	\N	\N	2024-03-15 11:24:01.33702	\N	\N	\N	\N	\N	\N	\N
20	3	6	demofirstname	demolastname	999999999	demo@gmail.com	6	1	\N	2024-02-15 12:29:39.426457	\N	\N	\N	0	\N	\N	\N	\N	\N	2024-04-26 00:00:00	\N	\N	\N	\N	\N	\N	\N
61	3	6	raj	patel	9777876767	raj@gmail.com	10	2	rj150324para0006	2024-03-15 12:22:20.037962	\N	\N	\N	0	\N	\N	\N	\N	\N	2024-03-15 12:22:20.037962	\N	\N	\N	\N	\N	\N	\N
39	2	6	family	friend	879898899789	x@gmail.com	3	2	\N	2024-03-06 09:24:16.190384	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	test	\N	\N	Cost Issue	\N	\N	\N
43	4	6	ad	asd	1241421414	x@gmail.com	1	6	\N	2024-03-07 15:33:08.444381	1	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
79	2	2	jenis	savaliya	9866766534	jenis@gmail.com	1	\N	SU210424SAJE0003	2024-04-21 17:28:05.598875	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	test	\N	\N	\N	\N	\N	\N
10	4	9	test	test	12312312	test@gmail.com	9	1	\N	2024-02-12 17:21:29.926629	\N	2024-04-25 13:57:01.699731	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
85	1	3	vatsal	test	9877898989	demo123@gmail.com	1	\N	SN250424TEVA0001	2024-04-25 15:55:56.315212	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
87	1	3	dharmesh	kanzariya	9788989898	demo123@gmail.com	1	\N	SU250424KADH0002	2024-04-25 16:07:40.086019	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
88	1	1	arsdasd	asd	6787676878	nikul123@gmail.com	1	\N	SN250424ASAR0003	2024-04-25 18:05:06.95849	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
89	1	4	saurav	patel	9898989989	aniyariyavijay441@gmail.com	1	\N	SU260424PASA0001	2024-04-26 14:48:37.90333	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
90	1	4	axay	test	5685658586	aniyariyavijay441@gmail.com	2	7	SU260424TEAX0002	2024-04-26 16:17:07.973966	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
81	4	2	raj	patel	9989474834	raj1234@gmail.com	1	\N	SN210424PARA0004	2024-04-21 20:04:56.349431	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
82	3	6	firstbusiness	lastbusiness	9875485794	firstbusiness123@gnail.com	1	\N	SU210424LAFI0003	2024-04-21 20:25:11.259003	\N	\N	\N	0	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
\.


                                                                                                                                                                                                                                                                                                       5197.dat                                                                                            0000600 0004000 0002000 00000000005 14612723503 0014255 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5199.dat                                                                                            0000600 0004000 0002000 00000020155 14612723503 0014267 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        7	10	test_firstname	test_lastname	1231321	\N	\N	1	\N	\N	test	testing@gmail.com	Feb	2024	2	\N	test1	test2	test3	test	\N	\N	\N	\N	\N	\N	\N	\N
18	22	first	last	1241421414	\N	\N	2	\N	\N	fever	x@gmail.com	Feb	2024	7	\N	street	city	state	4	\N	\N	\N	\N	\N	\N	\N	\N
9	12	test	vijay	1241421414	\N	\N	1	\N	\N	asadad	x@gmail.com	Feb	2024	8	\N	fghfh	hj	dasad	4	\N	\N	\N	\N	\N	\N	\N	\N
5	8	abc	cde	9313595665	\N	\N	1	\N	\N	abcd	vinit@gmail.com	Feb	2024	9	\N	xyz	rajkot	gujrat	4	\N	\N	\N	\N	\N	\N	\N	\N
24	28	demo	demo	1241421414	\N	\N	2	\N	\N	test	x@gmail.com	Feb	2024	6	\N	fghfh	hj	asdad	4	\N	\N	\N	\N	\N	\N	\N	\N
32	37	anil	chauhan	1241421414	\N	\N	2	\N	\N	test	x@gmail.com	Jan	2003	6	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
45	50	anil	anil	1241421414	\N	\N	3	\N	\N	test	x@gmail.com	Mar	2024	1	\N	fghfh	hj	gujrat	43432	\N	\N	\N	\N	\N	\N	\N	\N
49	54	ashish	ashish	9879987978	\N	\N	3	\N	\N	test	x@gmail.com	Mar	2024	8	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
11	14	asdad	asdad	1241421414	\N	\N	1	\N	\N	asdad	x@gmail.com	Feb	2024	6	\N	fghfh	hj	sada	4	\N	\N	\N	\N	\N	\N	\N	\N
12	16	sdfs	dffd	1241421414	\N	\N	2	\N	\N	sdf	x@gmail.com	Feb	2024	5	\N	fghfh	hj	fggf	4	\N	\N	\N	\N	\N	\N	\N	\N
13	17	cd	cd	1223344434	\N	\N	3	\N	\N	dasdsa	abc@gmail.com	Feb	2024	9	\N	vd	sdfs	sdfsf	12	\N	\N	\N	\N	\N	\N	\N	\N
21	25	adada	asda	1241421414	\N	\N	1	\N	\N	asda	x@gmail.com	Feb	2024	9	\N	fghfh	hj	asdad	4	\N	\N	\N	\N	\N	\N	\N	\N
23	27	cd	cd	999999	\N	\N	1	\N	\N	symptoms	x@gmail.com	Feb	2024	9	\N	fghfh	hj	sada	4	\N	\N	\N	\N	\N	\N	\N	\N
19	23	dasdas	adad	1241421544	\N	\N	3	\N	\N	adas	x@gmail.com	Feb	2024	8	\N	fghfh	hj	asda	4	\N	\N	\N	\N	\N	\N	\N	\N
20	24	adsad	aasda	896786869	\N	\N	2	\N	\N	asdasd	x@gmail.com	Feb	2024	8	\N	fghfh	hj	asdad	4	\N	\N	\N	\N	\N	\N	\N	\N
22	26	cd	cd	1241421414	\N	\N	3	\N	\N	symptoms	x@gmail.com	Feb	2024	9	\N	fghfh	hj	sada	4	\N	\N	\N	\N	\N	\N	\N	\N
59	66	dharmesh	kanzariya	979776976	\N	\N	1	\N	\N	test	x@gmail.com	Apr	2024	9	\N	b2	snagar	gujrat	385667	\N	\N	\N	\N	\N	\N	\N	\N
6	9	tatvasoft	tatvasoft	9343434434	\N	\N	2	\N	\N	adfafsdf	tatva@gmail.com	Feb	2024	9	\N	zsdd	fsdf	sdfsdf	9	\N	\N	\N	\N	\N	\N	\N	\N
17	21	tesing	testing	945949544	\N	\N	1	\N	\N	testing	x@gmail.com	Feb	2024	6	\N	fghfh	hj	asdad	4	\N	\N	\N	\N	\N	\N	\N	\N
58	65	yash	patel	923453494	\N	\N	1	\N	\N	\N	x@gmail.com	Mar	2024	7	\N	b2	surat	gujrat	385667	\N	\N	\N	\N	\N	\N	\N	\N
2	5	dsfs	fsdfsf	23213131312	\N	\N	1	\N	\N	werre	x@gmail.com	Feb	2024	8	\N	fghfh	hj	fghf	4	\N	\N	\N	\N	\N	\N	\N	\N
3	6	cd	cd	1223344434	\N	\N	2	\N	\N	dasdaad	a@gmail.com	Feb	2024	9	\N	vd	sdfs	asdsa	12	\N	\N	\N	\N	\N	\N	\N	\N
4	7	cd	cd	1241421414	\N	\N	3	\N	\N	dfgdg	x@gmail.com	Feb	2024	9	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
8	11	cd	cd	1241421414	\N	\N	2	\N	\N	asdas	x@gmail.com	Feb	2024	9	\N	fghfh	hj	asd	4	\N	\N	\N	\N	\N	\N	\N	\N
10	13	cd	cd	1223344434	\N	\N	3	\N	\N	sdadasda	abc@gmail.com	Feb	2024	9	\N	vd	sdfs	sdfsf	12	\N	\N	\N	\N	\N	\N	\N	\N
14	18	cd	cd	1223344434	\N	\N	1	\N	\N	asdasd	abc@gmail.com	Feb	2024	9	\N	vd	sdfs	daada	12	\N	\N	\N	\N	\N	\N	\N	\N
15	19	demo1	demo2	1241421414	\N	\N	3	\N	\N	demo	xyz@gmail.com	Feb	2024	8	\N	demostreet	democity	demostate	4	\N	\N	\N	\N	\N	\N	\N	\N
61	68	umang	gohil	9676678534	\N	\N	1	\N	\N	test	x@gmail.com	Apr	2024	10	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
62	69	ashvin	test	9679767934	\N	\N	1	\N	\N	\N	x@gmail.com	Apr	2024	10	\N	b2	morbi	gujrat	385667	\N	\N	\N	\N	\N	\N	\N	\N
25	29	test	test	1241421414	\N	\N	1	\N	\N	test	x@gmail.com	Feb	2024	9	\N	fghfh	hj	sada	4	\N	\N	\N	\N	\N	\N	\N	\N
42	47	dfgfd	dfgdg	1241421414	\N	\N	2	\N	\N	dgfgdh	x@gmail.com	Mar	2024	1	\N	fghfh	hj	sada	43432	\N	\N	\N	\N	\N	\N	\N	\N
43	48	cd	cd	1241421414	\N	\N	2	\N	\N	ghjghjgh	x@gmail.com	Mar	2024	2	\N	fghfh	hj	fgfgh	43432	\N	\N	\N	\N	\N	\N	\N	\N
60	67	vatsal	vatsal	96778687	\N	\N	1	\N	\N	test notes	x@gmail.com	Apr	2024	10	\N	b2	surat	gujrat	385667	\N	\N	\N	\N	\N	\N	\N	\N
37	42	cd	cd	9945846734	\N	\N	1	\N	\N	adas	x@gmail.com	Mar	2024	1	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
35	40	sandip	sandip	1241421414	\N	\N	1	\N	\N	test	x@gmail.com	Mar	2024	2	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
26	30	cd	cd	1241421414	\N	\N	1	\N	\N	test	x@gmail.com	Feb	2024	9	\N	fghfh	hj	sada	4	\N	\N	\N	\N	\N	\N	\N	\N
27	32	vinit	patel	1241421414	\N	\N	1	\N	\N	symptoms	x@gmail.com	Feb	2024	6	\N	fghfh	hj	asdad	43432	\N	\N	\N	\N	\N	\N	\N	\N
31	36	patel	vinit	1241421414	\N	\N	1	\N	\N	test symptoms	x@gmail.com	Mar	2024	1	\N	fghfh	hj	sada	43432	\N	\N	\N	\N	\N	\N	\N	\N
51	56	tirth	vinit	9878798978	\N	\N	1	\N	\N	test	x@gmail.com	Mar	2024	1	\N	b2	amadavd	gujrat	385667	\N	\N	\N	\N	\N	\N	\N	\N
52	57	parth	patel	978989833	\N	\N	1	\N	\N	test	x@gmail.com	Mar	2024	8	\N	b2	surat	gujrat	456565	\N	\N	\N	\N	\N	\N	\N	\N
53	58	yash	variya	879789879	\N	\N	1	\N	\N	test	x@gmail.com	Mar	2024	1	\N	b2	amadavd	gujrat	385667	\N	\N	\N	\N	\N	\N	\N	\N
28	33	cd	cd	1241421414	\N	\N	2	\N	\N	test	x@gmail.com	Feb	2024	7	\N	fghfh	hj	test3	43434	\N	\N	\N	\N	\N	\N	\N	\N
29	34	ms	dhoni	77777777777	\N	\N	3	\N	\N	test	x@gmail.com	Feb	2024	6	\N	test	ranchi	jharkhand	43432	\N	\N	\N	\N	\N	\N	\N	\N
30	35	first	last	1241421414	\N	\N	2	\N	\N	symptoms	x@gmail.com	Feb	2024	8	\N	fghfh	hj	sada	43432	\N	\N	\N	\N	\N	\N	\N	\N
33	38	cd	cd	1241421414	\N	\N	2	\N	\N	test	x@gmail.com	Mar	2024	1	\N	fghfh	hj	sada	43432	\N	\N	\N	\N	\N	\N	\N	\N
34	39	anil	anil	1241421414	\N	\N	2	\N	\N	test	x@gmail.com	Mar	2024	1	\N	fghfh	hj	sada	43432	\N	\N	\N	\N	\N	\N	\N	\N
36	41	raj	raj	1241421414	\N	\N	2	\N	\N	test	x@gmail.com	Mar	2024	1	\N	fghfh	hj	gujrat	43432	\N	\N	\N	\N	\N	\N	\N	\N
38	43	cd	cd	1241421414	\N	\N	3	\N	\N	asda	x@gmail.com	Mar	2024	1	\N	fghfh	hj	sada	43432	\N	\N	\N	\N	\N	\N	\N	\N
39	44	cd	cd	178778979787	\N	\N	2	\N	\N	cascs	x@gmail.com	Mar	2024	29	\N	fghfh	hj	sada	43432	\N	\N	\N	\N	\N	\N	\N	\N
40	45	cd	cd	89899898	\N	\N	3	\N	\N	optional	x@gmail.com	Mar	2024	1	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
44	49	cd	cd	1241421414	\N	\N	3	\N	\N	dfgfdgdgdf	x@gmail.com	Mar	2024	1	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
50	55	yash	yash	97787787787	\N	\N	3	\N	\N	test	x@gmail.com	Mar	2024	2	\N	b2	surat	gujrat	356567	\N	\N	\N	\N	\N	\N	\N	\N
54	59	hardev	zala	967876887	\N	\N	2	\N	\N	test	x@gmail.com	Mar	2024	8	\N	b2	snagar	gujrat	356567	\N	\N	\N	\N	\N	\N	\N	\N
55	60	ashish	zapadiya	9678677777	\N	\N	3	\N	\N	test	x@gmail.com	Mar	2024	8	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
56	61	ashish	ziniya	976786767	\N	\N	1	\N	\N	test	x@gmail.com	Mar	2024	8	\N	b2	snagar	gujrat	356567	\N	\N	\N	\N	\N	\N	\N	\N
57	62	monank	patel	965675566	\N	\N	2	\N	\N	test	x@gmail.com	Mar	2024	9	\N	b2	surat	gujrat	356567	\N	\N	\N	\N	\N	\N	\N	\N
41	46	cd	cd	1241421414	\N	\N	2	\N	\N	fgjfgjf	x@gmail.com	Mar	2024	1	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
63	70	sandip	dabhi	9876978434	\N	\N	1	\N	\N	test symptoms	x@gmail.com	Apr	2024	14	\N	k2, surat	snagar	rajkot	343424	\N	\N	\N	\N	\N	\N	\N	\N
64	71	tesnew	testlast	9889843934	\N	\N	3	\N	\N	dssd	x@gmail.com	Apr	2024	14	1	k2, snagar	surat	surat	343424	\N	\N	\N	\N	\N	\N	\N	\N
76	83	demotest	demotesting	9999967897	\N	\N	3	\N	\N	asd	demo123@gmail.com	Apr	2024	18	1	k2, surat	snagar	surat	343424	\N	\N	\N	\N	\N	\N	\N	\N
72	79	jaydeep	test	9566766534	\N	\N	3	\N	\N	testtest	jaydeep1234@gmail.com	Apr	2024	12	\N	b1	surat	surat	349493	\N	\N	\N	\N	\N	\N	\N	\N
74	81	bhaudip	test	9866765434	\N	k2, surat snagar 2 343424	2	\N	\N	test	jaydeep1234@gmail.com	Apr	2024	16	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N
75	82	sumit	test	9586956834	\N	\N	3	\N	\N	test	jaydeep1234@gmail.com	Apr	2024	4	\N	b1	surat	surat	349493	\N	\N	\N	\N	\N	\N	\N	\N
78	85	vatsal	test	9877898989	\N	\N	2	\N	\N	\N	demo123@gmail.com	Apr	2024	18	\N	test	snagar	snagar	385667	\N	\N	\N	\N	\N	\N	\N	\N
80	87	dharmesh	kanzariya	9788989898	\N	\N	3	\N	\N	\N	demo123@gmail.com	Apr	2024	12	\N	teststreet	surat	surat	385667	\N	\N	\N	\N	\N	\N	\N	\N
81	88	arsdasd	asd	6787676878	\N	\N	2	\N	\N	\N	nikul123@gmail.com	Apr	2024	12	\N	trstt	snagar	snagar	385667	\N	\N	\N	\N	\N	\N	\N	\N
82	89	saurav	patel	9898989989	\N	\N	3	\N	\N	\N	aniyariyavijay441@gmail.com	Apr	2024	20	1	teststreet	surat	surat	385667	\N	\N	\N	\N	\N	\N	\N	\N
16	20	demofirstname	demolastname	9999999999	surat b2 	\N	2	\N	\N	fever	demo@gmail.com	Apr	2024	12	\N	demostreet	rajkot	gujrat	9	\N	\N	\N	\N	\N	\N	\N	\N
83	90	axay	test	5685658586	\N	\N	3	\N	\N	\N	aniyariyavijay441@gmail.com	Apr	2024	19	\N	teststreet	snagar	surat	385667	\N	\N	\N	\N	\N	\N	\N	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                                                   5201.dat                                                                                            0000600 0004000 0002000 00000000115 14612723503 0014241 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	10	113	\N	\N	\N
2	11	114	\N	\N	\N
3	13	115	\N	\N	\N
4	27	116	\N	\N	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                   5203.dat                                                                                            0000600 0004000 0002000 00000000020 14612723503 0014236 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	81	15	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                5205.dat                                                                                            0000600 0004000 0002000 00000003116 14612723503 0014251 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        3	65	\N	\N	\N	\N	created by admin demofirstname	Admin	2024-03-19 16:45:46.525397	\N	\N	\N	\N
4	42	\N	\N	\N	\N	notes changed by admin	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-11 12:17:04.212568	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-11 12:18:18.438434	\N	\N
6	46	\N	\N	\N	\N	concluded by vinit patel	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-16 18:54:51.64936	\N	\N	\N	\N
7	69	\N	\N	\N	test notes by provider	\N	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-17 13:01:55.977856	\N	\N	\N	\N
8	62	\N	\N	\N	\N	test notes by admin	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-19 15:19:17.270725	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-19 16:03:11.691994	\N	\N
10	49	\N	\N	\N	hellovinit	\N	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-24 03:28:39.879911	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-24 03:32:14.456299	\N	\N
5	44	\N	\N	\N	conclude	test notes add by admin	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-12 14:28:19.330276	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-24 05:07:47.957713	\N	\N
11	55	\N	\N	\N	\N	test	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-24 09:38:42.987872	\N	\N	\N	\N
12	45	\N	\N	\N	adsasdassa	\N	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-25 11:44:17.968428	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-25 11:44:23.872275	\N	\N
1	12	\N	\N	\N	abcd	test	Admin	2024-02-28 10:27:01.913104	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-25 14:36:07.210103	\N	\N
14	87	\N	\N	\N	test notes	\N	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-25 16:07:45.98511	\N	\N	\N	\N
15	43	\N	\N	\N	\N	wqerwe	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 12:41:23.955398	\N	\N	\N	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                  5207.dat                                                                                            0000600 0004000 0002000 00000014503 14612723503 0014255 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	12	2	\N	\N	\N	asbasc	2024-02-28 12:11:00.913104	\N	\N
2	13	5	\N	\N	\N	abcd	2024-02-29 15:23:04.136355	\N	\N
3	14	5	\N	\N	\N	abcdassa	2024-02-29 15:25:59.160083	\N	\N
4	16	5	\N	\N	\N	this is additional notes	2024-02-29 16:10:20.902115	\N	\N
5	23	5	\N	\N	\N	cancel by admin	2024-03-01 11:14:07.265177	\N	\N
7	30	10	\N	\N	\N	this is block by admin	2024-03-01 14:18:16.713729	\N	\N
8	32	10	\N	\N	\N	block by admin	2024-03-01 14:51:41.406467	\N	\N
9	12	10	\N	\N	\N	dsa	2024-03-01 14:54:55.634682	\N	\N
12	35	5	\N	\N	\N	\N	2024-03-06 09:19:12.404296	\N	\N
13	36	5	\N	\N	\N	\N	2024-03-06 09:19:27.469915	\N	\N
14	37	5	\N	\N	\N	\N	2024-03-06 09:21:34.25226	\N	\N
15	38	5	\N	\N	\N	\N	2024-03-06 09:23:03.901696	\N	\N
16	12	10	\N	\N	\N	\N	2024-03-06 09:26:32.046154	\N	\N
17	41	5	\N	\N	\N	\N	2024-03-06 09:41:58.355601	\N	\N
99	49	2	\N	\N	7	\N	2024-04-19 14:39:49.364946	\N	\N
10	17	2	\N	\N	3	transfer to physician first	2024-03-01 17:22:33.116572	\N	\N
11	33	2	\N	\N	3	this request is transfer to physician first last	2024-03-04 10:20:53.790648	\N	\N
100	56	5	\N	\N	\N	\N	2024-04-19 16:22:05.92313	\N	\N
31	33	10	\N	\N	\N	\N	2024-03-11 09:57:00.172425	\N	\N
32	25	3	\N	\N	\N	\N	2024-03-11 14:54:31.961437	\N	\N
33	26	5	\N	\N	\N	out of service area	2024-03-11 15:46:00.591414	\N	\N
35	8	6	\N	\N	\N	\N	2024-03-13 17:34:16.082228	\N	\N
36	35	6	\N	\N	\N	\N	2024-03-13 17:41:36.357434	\N	\N
37	61	2	\N	\N	2	assign to abc 	2024-03-15 12:24:29.1081	\N	\N
38	60	2	\N	\N	3	assign to first	2024-03-15 12:24:55.402729	\N	\N
39	45	10	\N	\N	\N	cost issues	2024-03-18 18:13:14.546224	\N	\N
40	29	3	\N	\N	\N	\N	2024-03-19 09:38:21.958547	\N	\N
41	50	2	\N	\N	6	assign to yash	2024-04-01 11:53:07.922483	\N	\N
42	54	5	\N	\N	\N	\N	2024-04-01 11:53:19.345948	\N	\N
43	65	5	\N	\N	\N	test additional notes	2024-04-01 11:53:56.688826	\N	\N
44	47	10	\N	\N	\N	payment issues	2024-04-01 11:55:13.56208	\N	\N
45	50	2	10	\N	10	transfer to parth	2024-04-01 12:02:03.735762	\N	\N
46	50	10	\N	\N	\N	\N	2024-04-01 12:02:26.411706	\N	\N
47	17	3	\N	\N	\N	\N	2024-04-01 12:03:13.270393	\N	\N
49	17	5	\N	\N	\N	cancel test	2024-04-01 12:03:52.450617	\N	\N
50	27	3	\N	\N	\N	\N	2024-04-01 12:05:05.55164	\N	\N
51	40	2	\N	\N	2	assign to abc	2024-04-01 12:05:59.203261	\N	\N
52	48	2	\N	\N	1	assign to test1	2024-04-01 12:06:08.645111	\N	\N
53	40	3	\N	\N	\N	\N	2024-04-01 12:06:56.822252	\N	\N
54	60	3	\N	\N	\N	\N	2024-04-01 12:08:39.209611	\N	\N
55	42	2	\N	\N	10	sdfas	2024-04-02 09:46:31.787215	\N	\N
56	56	2	\N	\N	7	gdgffg	2024-04-02 09:48:03.838258	\N	\N
57	59	2	\N	\N	6	xcv	2024-04-02 09:52:26.545991	\N	\N
58	57	10	\N	\N	\N	no reply to text	2024-04-08 12:25:02.146675	\N	\N
59	43	10	\N	\N	\N	unavailable	2024-04-08 12:35:39.845991	\N	\N
60	58	2	\N	\N	6	assign to yash	2024-04-08 14:21:41.980521	\N	\N
61	58	2	2	\N	2	transfer to abc	2024-04-10 14:51:07.103625	\N	\N
62	66	2	\N	\N	10	assign to parth	2024-04-11 10:33:59.171281	\N	\N
63	34	5	\N	\N	\N	no reply to call	2024-04-11 10:34:40.047195	\N	\N
64	39	10	\N	\N	\N	cost issues	2024-04-11 10:34:59.26707	\N	\N
65	67	2	\N	\N	6	assign to yash	2024-04-12 13:37:00.107953	\N	\N
66	12	2	\N	\N	2	assign to abc	2024-04-12 13:37:20.124928	\N	\N
67	47	2	\N	\N	5	assign to raj	2024-04-12 13:45:28.870892	\N	\N
68	32	2	\N	\N	11	assign to sumit	2024-04-12 13:46:30.572398	\N	\N
69	57	5	\N	\N	\N	not reply to text or messages	2024-04-12 13:52:09.190189	\N	\N
70	39	10	\N	\N	\N	there is cost  issuses	2024-04-12 13:55:23.49435	\N	\N
71	12	10	\N	\N	\N	\N	2024-04-12 14:08:48.695055	\N	\N
72	12	10	\N	\N	\N	\N	2024-04-12 14:09:06.192288	\N	\N
73	47	10	\N	\N	\N	\N	2024-04-12 14:09:50.395089	\N	\N
74	68	2	\N	\N	11	assign to sumit	2024-04-12 14:12:58.445554	\N	\N
75	32	10	\N	\N	\N	\N	2024-04-12 14:13:07.084546	\N	\N
76	42	2	7	\N	7	transfer to vinit	2024-04-12 14:15:18.363302	\N	\N
77	44	1	\N	\N	7	assign to vinit	2024-04-15 15:06:27.846969	\N	\N
78	44	2	\N	\N	7	\N	2024-04-15 15:15:09.504674	\N	\N
79	42	2	5	\N	5	transfer to raj	2024-04-15 15:27:08.261315	\N	\N
80	44	4	\N	\N	\N	\N	2024-04-15 15:33:42.676086	\N	\N
81	44	6	\N	\N	\N	\N	2024-04-15 17:05:38.992286	\N	\N
82	56	4	\N	\N	\N	\N	2024-04-15 19:07:54.255024	\N	\N
83	45	1	\N	\N	7	assign to vinit	2024-04-16 09:54:17.464403	\N	\N
84	46	1	\N	\N	7	assign to vinit patel	2024-04-16 09:54:37.414876	\N	\N
85	45	2	\N	\N	7	\N	2024-04-16 09:55:22.472674	\N	\N
86	46	2	\N	\N	7	\N	2024-04-16 10:01:19.643362	\N	\N
87	55	1	\N	\N	7	assign to vinit patel	2024-04-16 10:02:21.224199	\N	\N
88	55	2	\N	\N	7	\N	2024-04-16 10:02:44.735266	\N	\N
89	45	4	\N	\N	\N	\N	2024-04-16 10:04:28.117784	\N	\N
90	46	4	\N	\N	\N	\N	2024-04-16 10:05:35.140376	\N	\N
91	55	4	\N	\N	\N	\N	2024-04-16 10:05:40.387917	\N	\N
92	45	5	\N	\N	\N	\N	2024-04-16 10:12:02.203193	\N	\N
93	45	6	\N	\N	\N	\N	2024-04-16 10:31:52.830703	\N	\N
94	46	5	\N	\N	\N	\N	2024-04-16 12:32:24.030856	\N	\N
95	55	5	\N	\N	\N	\N	2024-04-16 17:15:46.855983	\N	\N
96	46	6	\N	\N	\N	\N	2024-04-16 18:48:35.193778	\N	\N
97	46	8	\N	\N	\N	concluded by vinit patel	2024-04-16 18:54:51.6968	\N	\N
98	49	1	\N	\N	7	assign to vinit	2024-04-19 14:39:18.576336	\N	\N
101	42	10	\N	\N	\N	\N	2024-04-20 22:46:11.008554	\N	\N
102	42	10	\N	\N	\N	\N	2024-04-20 22:46:15.545961	\N	\N
103	48	10	\N	\N	\N	\N	2024-04-20 22:46:46.70615	\N	\N
104	48	10	\N	\N	\N	\N	2024-04-20 22:46:56.244388	\N	\N
105	12	11	\N	\N	\N	testreason	2024-04-23 23:18:24.020961	\N	\N
106	55	6	\N	\N	\N	\N	2024-04-24 05:07:30.873634	\N	\N
107	44	8	\N	\N	\N	conclude	2024-04-24 05:07:47.958063	\N	\N
108	55	8	\N	\N	\N	test	2024-04-24 09:38:43.017446	\N	\N
109	12	11	\N	\N	\N	testreason	2024-04-25 13:48:00.269468	\N	\N
110	32	3	\N	\N	\N	test	2024-04-25 13:49:24.783391	\N	\N
111	39	3	\N	\N	\N	test	2024-04-25 13:56:23.579985	\N	\N
112	45	3	\N	\N	\N	reason	2024-04-25 13:56:50.399469	\N	\N
113	10	9	\N	\N	\N	\N	2024-04-25 13:57:01.699922	\N	\N
114	11	9	\N	\N	\N	\N	2024-04-25 13:57:07.321851	\N	\N
115	13	9	\N	\N	\N	\N	2024-04-25 13:58:28.415662	\N	\N
116	27	9	\N	\N	\N	\N	2024-04-25 14:02:53.820256	\N	\N
117	47	3	\N	\N	\N	test	2024-04-25 14:34:58.363839	\N	\N
118	62	11	\N	\N	\N	reason	2024-04-25 14:35:11.945136	\N	\N
119	12	3	\N	\N	\N	tset	2024-04-25 14:36:43.589753	\N	\N
120	49	10	\N	\N	\N	\N	2024-04-25 14:44:47.673656	\N	\N
121	58	10	\N	\N	\N	\N	2024-04-25 14:46:19.675437	\N	\N
122	43	1	\N	\N	6	assign to yash	2024-04-25 14:46:56.222728	\N	\N
123	69	1	\N	\N	2	assign to abc	2024-04-25 14:47:43.12205	\N	\N
124	61	10	\N	\N	\N	\N	2024-04-25 14:50:33.697158	\N	\N
125	39	3	\N	\N	\N	wqqwae	2024-04-26 12:40:53.36353	\N	\N
\.


                                                                                                                                                                                             5209.dat                                                                                            0000600 0004000 0002000 00000000005 14612723503 0014247 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5211.dat                                                                                            0000600 0004000 0002000 00000016427 14612723503 0014257 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        3	17	Tables_41154a.sql	2024-02-14 10:02:48.680476	\N	\N	\N	\N	\N	\N	\N	\N	\N
4	18	SQLQuery1_7fa0cb.sql	2024-02-14 10:06:20.338247	\N	\N	\N	\N	\N	\N	\N	\N	\N
5	19	assignment-1_sql_4ddec4.txt	2024-02-14 17:02:12.497485	\N	\N	\N	\N	\N	\N	\N	\N	\N
6	20	assignment-4_sql_ca76c7.txt	2024-02-15 12:29:39.530409	\N	\N	\N	\N	\N	\N	\N	\N	\N
7	21	assignment-3_sql_876869.txt	2024-02-15 18:49:53.6569	\N	\N	\N	\N	\N	\N	\N	\N	\N
8	22	orders_2e4e3d.sql	2024-02-16 18:25:26.664781	\N	\N	\N	\N	\N	\N	\N	\N	\N
9	22	salesman_237efa.sql	2024-02-16 18:25:26.708108	\N	\N	\N	\N	\N	\N	\N	\N	\N
10	22	customer_463f45.sql	2024-02-16 18:25:26.712202	\N	\N	\N	\N	\N	\N	\N	\N	\N
11	23	customer_aab54c.sql	2024-02-16 19:18:04.751335	\N	\N	\N	\N	\N	\N	\N	\N	\N
12	24	customer_2cdb78.sql	2024-02-16 19:20:39.451947	\N	\N	\N	\N	\N	\N	\N	\N	\N
13	25	customer_e76d3a.sql	2024-02-16 19:21:30.486036	\N	\N	\N	\N	\N	\N	\N	\N	\N
14	26	Session 2 (1) (1)_df9524.txt	2024-02-20 10:33:35.81577	\N	\N	\N	\N	\N	\N	\N	\N	\N
16	28	.~lock.HalloDoc - DB_2d8cb3.xlsx#	2024-02-20 11:39:47.626866	\N	\N	\N	\N	\N	\N	\N	\N	\N
17	29	MVC_1ddf34.pdf	2024-02-21 09:36:36.898869	\N	\N	\N	\N	\N	\N	\N	\N	\N
19	30	Phase 1 - Training Plan .net (1)_9c5886.pdf	2024-02-23 09:26:37.789937	\N	\N	\N	\N	\N	\N	\N	\N	\N
20	16	MVC.pdf	2024-02-26 15:37:55.466128	\N	\N	\N	\N	\N	\N	\N	\N	\N
27	32	SRS-23-24-Trainees-21Feb24 (1)_03ba0a.pdf	2024-03-01 14:39:59.469283	\N	\N	\N	\N	\N	\N	\N	\N	\N
28	34	Session 2 (1)_4daef6.txt	2024-03-01 14:47:57.722323	\N	\N	\N	\N	\N	\N	\N	\N	\N
29	35	SRS-23-24-Trainees-21Feb24 (1)_26ba17.pdf	2024-03-04 10:59:50.54645	\N	\N	\N	\N	\N	\N	\N	\N	\N
30	36	Session 2 (1) (1)_eb8963.txt	2024-03-04 11:06:39.531149	\N	\N	\N	\N	\N	\N	\N	\N	\N
54	27	MVC (2)_505141.pdf	2024-03-05 18:09:41.834304	\N	\N	\N	\N	\N	\N	\N	\N	\N
57	39	plan_till_1feb2024 (2)_fee3bc_783290.pdf	2024-03-06 09:24:16.195928	\N	\N	\N	\N	\N	\N	\N	\N	\N
60	25	plan_till_1feb2024 (2)_fee3bc_322372.pdf	2024-03-06 11:45:22.727221	\N	\N	\N	\N	\N	\N	\N	\N	\N
61	25	salesman_1784e8.sql	2024-03-06 11:45:22.728818	\N	\N	\N	\N	\N	\N	\N	\N	\N
84	45	MVC (2)_505141 (4)_d31132.pdf	2024-04-18 15:45:50.242841	\N	\N	\N	\N	\N	\N	\N	\N	\N
63	25	orders_beac48.sql	2024-03-08 15:34:26.161219	\N	\N	\N	\N	\N	\N	\N	1	\N
55	27	MVC (3)_b38ee6.pdf	2024-03-05 18:20:16.74789	\N	\N	\N	\N	\N	\N	\N	1	\N
65	33	submit_e9b860 (8)_caab09.html	2024-03-14 12:12:45.874266	\N	\N	\N	\N	\N	\N	\N	\N	\N
64	27	Session 2 (1) (1)_f6e472.txt	2024-03-13 12:14:41.3151	\N	\N	\N	\N	\N	\N	\N	1	\N
62	50	MVC (2)_505141_d70007.pdf	2024-03-07 15:37:06.411043	\N	\N	\N	\N	\N	\N	\N	1	\N
67	50	1_20240329_20e91e.xlsx	2024-04-01 12:00:42.418174	\N	\N	\N	\N	\N	\N	\N	\N	\N
68	50	1_20240326_1887e2.xlsx	2024-04-01 12:00:42.419026	\N	\N	\N	\N	\N	\N	\N	\N	\N
66	50	HalloDocMVCNew1_c7bb22	2024-04-01 12:00:42.411486	\N	\N	\N	\N	\N	\N	\N	1	\N
69	12	1_20240329_20e91e (4)_a141ce.xlsx	2024-04-08 14:03:39.20383	\N	\N	\N	\N	\N	\N	\N	\N	\N
70	66	New Text Document_f50e9b.txt	2024-04-10 14:53:56.243974	\N	\N	\N	\N	\N	\N	\N	\N	\N
71	67	Session 2 (1) (1)_f6e472_a829e3.txt	2024-04-11 14:00:52.530169	\N	\N	\N	\N	\N	\N	\N	\N	\N
72	68	New Text Document_405983.txt	2024-04-12 14:40:06.394985	\N	\N	\N	\N	\N	\N	\N	\N	\N
73	44	New Text Document_405983_81f388.txt	2024-04-15 18:12:25.643533	\N	\N	\N	\N	\N	\N	\N	\N	\N
74	44	MVC (2)_505141 (4)_ee8455.pdf	2024-04-15 19:47:10.488312	\N	\N	\N	\N	\N	\N	\N	\N	\N
75	44	MVC (2)_505141 (4)_6800c2.pdf	2024-04-15 19:47:49.42699	\N	\N	\N	\N	\N	\N	\N	\N	\N
76	44	SRS-23-24-Trainees-21Feb24_648a0a.pdf	2024-04-15 19:50:08.060501	\N	\N	\N	\N	\N	\N	\N	\N	\N
85	42	AuthorizationRepository (1)_c3448b.cs	2024-04-19 17:19:17.231634	\N	\N	\N	\N	\N	\N	\N	1	\N
86	42	SessionUtilsRepository_61716c.cs	2024-04-19 17:19:17.286294	\N	\N	\N	\N	\N	\N	\N	1	\N
118	42	HalloDocMVC_New_7304ce	2024-04-19 18:24:26.491873	\N	\N	\N	\N	\N	\N	\N	1	\N
121	42	1_20240412_3b2732.xlsx	2024-04-19 18:36:13.986026	\N	\N	\N	\N	\N	\N	\N	\N	\N
119	42	CloseCase (2)_667cf0.htm	2024-04-19 18:25:25.484393	\N	\N	\N	\N	\N	\N	\N	1	\N
120	42	New Text Document_08a82e.txt	2024-04-19 18:27:53.840159	\N	\N	\N	\N	\N	\N	\N	1	\N
123	42	New Text Document_08a82e_c095d2.txt	2024-04-19 18:40:07.327835	\N	\N	\N	\N	\N	\N	\N	\N	\N
122	42	CloseCase (2)_667cf0 (2)_89208d.htm	2024-04-19 18:40:07.318575	\N	\N	\N	\N	\N	\N	\N	1	\N
124	5	SRS-23-24-Trainees-8March24_e8991a.pdf	2024-04-20 12:55:09.589929	\N	\N	\N	\N	\N	\N	\N	\N	\N
125	5	Vibrant Gujarat Event Participation_d959a2.pdf	2024-04-20 16:30:29.112614	\N	\N	\N	\N	\N	\N	\N	\N	\N
126	5	practice-problem-statements_bae0f9.pdf	2024-04-20 16:30:29.241885	\N	\N	\N	\N	\N	\N	\N	\N	\N
127	5	200200107072 _final _report_243f82.pdf	2024-04-23 21:32:32.711376	\N	\N	\N	\N	\N	\N	\N	\N	\N
128	83	docuri-com_online-project_24a5cd.pdf	2024-04-23 23:08:50.698922	\N	\N	\N	\N	\N	\N	\N	\N	\N
2	16	submit_e9b860.html	2024-02-14 09:48:42.965692	\N	\N	\N	\N	\N	\N	\N	1	\N
18	16	Plan_till_1Feb2024.pdf	2024-02-22 10:42:14.574204	\N	\N	\N	\N	\N	\N	\N	1	\N
21	16	Home.cshtml	2024-02-26 19:27:20.928391	\N	\N	\N	\N	\N	\N	\N	1	\N
23	16	Session 2 (1).txt	2024-02-27 09:26:35.704742	\N	\N	\N	\N	\N	\N	\N	1	\N
22	16	SRS-23-24-Trainees-21Feb24.pdf	2024-02-27 09:26:13.161508	\N	\N	\N	\N	\N	\N	\N	1	\N
24	16	Phase 1 - Training Plan .net (1).pdf	2024-02-27 09:27:23.789476	\N	\N	\N	\N	\N	\N	\N	1	\N
25	16	Phase 1 - Training Plan .net.pdf	2024-02-27 09:27:23.791417	\N	\N	\N	\N	\N	\N	\N	1	\N
26	16	Phase 1 - Training Plan .net.pdf	2024-02-27 10:30:32.74526	\N	\N	\N	\N	\N	\N	\N	1	\N
129	16	200200107023_Internship_Report_29c405.pdf	2024-04-24 04:33:57.710582	\N	\N	\N	\N	\N	\N	\N	\N	\N
130	16	200200107072_CompletionCertificate_b7192c.pdf	2024-04-24 04:33:57.738678	\N	\N	\N	\N	\N	\N	\N	\N	\N
131	16	3. NGINX, APACHE, SSL ENCRYPTION COURCE (1)_a684b8.pdf	2024-04-24 04:33:57.746321	\N	\N	\N	\N	\N	\N	\N	\N	\N
132	16	Final Year Internship Report_df9f5c.docx	2024-04-24 04:34:21.362267	\N	\N	\N	\N	\N	\N	\N	\N	\N
134	44	200200107072 _final _report_e2d7cf.pdf	2024-04-24 05:03:27.449219	\N	\N	\N	\N	\N	\N	\N	\N	\N
135	44	200200107120_Sem8Internship_fe7a86.pdf	2024-04-24 05:07:04.361886	\N	\N	\N	\N	\N	\N	\N	\N	\N
136	10	internship_report_200200107072_9c8c35.pdf	2024-04-25 14:01:26.943354	\N	\N	\N	\N	\N	\N	\N	\N	\N
137	59	internship_report_200200107072_19d52a.pdf	2024-04-25 16:12:24.94829	\N	\N	\N	\N	\N	\N	\N	1	\N
138	59	internship_report_200200107072_f813b4.pdf	2024-04-25 16:15:04.954703	\N	\N	\N	\N	\N	\N	\N	1	\N
139	59	Assignment 2-HMS (3)_d277b1.pdf	2024-04-25 16:18:15.557639	\N	\N	\N	\N	\N	\N	\N	1	\N
140	59	Assignment 2-HMS (3)_d277b1_a0eb65.pdf	2024-04-25 16:31:34.602311	\N	\N	\N	\N	\N	\N	\N	1	\N
141	59	internship_report_200200107072_f813b4_870ec6.pdf	2024-04-25 16:31:34.643367	\N	\N	\N	\N	\N	\N	\N	1	\N
143	59	SRS-23-24-Trainees-8March24_e8991a (1)_1d1769.pdf	2024-04-25 16:42:24.176678	\N	\N	\N	\N	\N	\N	\N	\N	\N
142	59	Assignment 2-HMS (1)_b40b6c.pdf	2024-04-25 16:41:14.867918	\N	\N	\N	\N	\N	\N	\N	1	\N
145	56	internship_report_200200107072_f813b4_870ec6_2a0c67.pdf	2024-04-25 16:59:20.021372	\N	\N	\N	\N	\N	\N	\N	\N	\N
144	56	Assignment 2-HMS (3)_d277b1_a0eb65_5334d3.pdf	2024-04-25 16:59:19.975044	\N	\N	\N	\N	\N	\N	\N	1	\N
77	56	New Text Document_405983_e85f79.txt	2024-04-16 17:39:31.489889	\N	\N	\N	\N	\N	\N	\N	1	\N
146	59	internship_report_200200107072_f813b4 (1)_f4d809.pdf	2024-04-26 12:39:53.410027	\N	\N	\N	\N	\N	\N	\N	1	\N
147	89	internship_report_200200107072_f813b4_870ec6 (1)_6ee1a9.pdf	2024-04-26 14:49:49.831764	\N	\N	\N	\N	\N	\N	\N	\N	\N
\.


                                                                                                                                                                                                                                         5214.dat                                                                                            0000600 0004000 0002000 00000010226 14612723503 0014251 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        24	teest role	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:46:57.055175	\N	\N	1	\N	1
40	test	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-01 12:36:37.204705	\N	\N	1	\N	1
39	test	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-28 12:43:04.615131	\N	\N	1	\N	2
38	physician2	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-27 11:08:49.938722	\N	\N	1	\N	2
20	test role	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:43:16.374518	\N	\N	1	\N	1
37	patient2	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-27 11:08:35.402305	\N	\N	1	\N	3
36	test role5	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-27 11:08:15.9176	\N	\N	1	\N	2
31	sdfs	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:56:09.711363	\N	\N	1	\N	2
11	Halo Admin	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 14:36:30.912537	\N	\N	1	\N	1
22	test role	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:46:03.517652	\N	\N	1	\N	1
6	Medicine Specialist	21c57981-a679-4b62-8eee-57c1ce429643	2024-02-26 09:51:30.912537	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-22 10:34:51.047642	1	\N	2
7	Physician1	21c57981-a679-4b62-8eee-57c1ce429643	2024-02-26 09:51:30.912537	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-23 10:34:51.047642	1	\N	2
10	Master Admin	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 14:36:30.912537	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 10:34:51.047642	0	\N	1
25	test role	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:47:18.236996	\N	\N	1	\N	1
26	testb rolr	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:49:19.171712	\N	\N	1	\N	1
28	sefsd	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:54:19.505004	\N	\N	1	\N	3
29	asd	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:54:49.807911	\N	\N	1	\N	3
13	test1	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 14:36:30.912537	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-15 13:25:01.39245	1	\N	2
15	Himanshi	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 14:36:30.912537	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-15 13:28:07.357936	1	\N	2
35	as	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-27 10:53:41.150831	\N	\N	1	\N	4
21	test role	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:44:28.7264	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-17 18:38:58.081133	1	\N	1
27	physician role	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:53:43.949447	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-25 17:30:42.475736	1	\N	2
46	SubAdmin	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-25 19:16:49.787852	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 13:42:47.030237	0	\N	1
23	teest role	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:46:30.897299	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-20 23:58:02.128689	1	\N	1
12	Nikunj	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 14:36:30.912537	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-25 17:30:55.441155	1	\N	1
30	Master Physician	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 18:55:43.630133	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 13:43:26.568759	0	\N	2
41	SubPhysician	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-08 14:04:59.631069	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 13:43:54.959831	0	\N	2
42	Physician Test	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-15 12:09:05.740147	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 13:44:41.373311	0	\N	2
43	physicianrole	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-15 12:52:28.244937	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 13:46:09.77944	0	\N	2
14	Tirth	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 14:36:30.912537	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-15 13:25:19.765381	1	\N	2
16	test2	21c57981-a679-4b62-8eee-57c1ce429643	2024-03-26 14:36:30.912537	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-15 13:28:48.229606	1	\N	2
44	AdminRole	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-15 12:54:07.031542	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 13:50:53.50594	0	\N	1
45	SuperAdmin	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-25 19:16:27.364744	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 13:52:04.678952	0	\N	1
5	Neurologist	21c57981-a679-4b62-8eee-57c1ce429643	2024-02-26 09:51:30.912537	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-21 10:34:51.047642	1	\N	2
47	testpatient	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 14:00:51.095993	\N	\N	1	\N	3
\.


                                                                                                                                                                                                                                                                                                                                                                          5215.dat                                                                                            0000600 0004000 0002000 00000002751 14612723503 0014256 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	22	17
2	22	18
9	24	17
10	24	18
11	24	17
12	24	18
13	25	17
14	25	18
15	26	18
16	26	19
18	28	29
19	29	28
21	31	25
22	35	19
23	36	25
24	37	29
25	38	24
26	39	16
27	39	17
28	39	23
29	40	20
36	13	25
42	16	24
43	21	21
44	23	17
45	23	18
46	27	24
47	27	25
48	12	19
49	12	20
37	14	25
179	47	16
40	15	28
41	15	28
54	10	21
55	10	22
56	10	24
57	10	25
58	10	30
59	10	31
60	10	32
61	10	34
62	10	35
63	10	36
64	10	37
65	10	39
66	10	40
67	10	41
68	10	42
69	10	43
70	10	44
71	10	45
72	10	38
73	10	57
74	10	58
75	10	59
76	10	60
77	10	61
78	10	62
79	10	63
80	10	64
81	10	65
82	46	21
83	46	22
84	46	24
85	46	25
86	46	30
87	46	32
88	46	34
89	46	37
90	46	39
91	46	40
92	46	41
93	46	42
94	46	43
95	46	44
96	46	45
97	46	38
98	46	58
99	46	59
100	46	60
101	46	61
102	46	63
103	46	62
104	46	64
105	46	65
106	46	57
107	30	23
108	30	28
109	30	29
110	30	48
111	30	52
112	30	53
113	30	54
114	30	55
115	30	56
116	41	23
117	41	28
118	41	29
119	41	48
120	41	53
121	41	54
122	41	55
123	41	56
124	42	23
125	42	28
126	42	29
127	42	48
128	42	52
129	42	53
130	42	54
131	42	55
132	43	28
133	43	29
134	43	48
135	43	52
136	43	53
137	43	54
138	43	55
139	43	56
140	44	21
141	44	24
142	44	25
143	44	30
144	44	32
145	44	37
146	44	39
147	44	41
148	44	42
149	44	43
150	44	44
151	44	45
152	44	38
153	44	58
154	44	59
155	44	60
156	44	61
157	44	63
158	44	64
159	44	65
160	44	57
161	45	21
162	45	22
163	45	24
164	45	25
165	45	30
166	45	39
167	45	41
168	45	42
169	45	45
170	45	38
171	45	59
172	45	60
173	45	61
174	45	63
175	45	62
176	45	64
177	45	65
178	45	57
\.


                       5218.dat                                                                                            0000600 0004000 0002000 00000000307 14612723503 0014254 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	test	979776976	\N	7	2	\N	6	2024-04-10 18:41:56.235901	2024-04-10 18:41:56.235901	1	1	\N
2	check your patient	967696734	\N	5	2	\N	7	2024-04-12 18:41:56.235901	2024-04-12 18:41:56.235901	1	1	\N
\.


                                                                                                                                                                                                                                                                                                                         5220.dat                                                                                            0000600 0004000 0002000 00000005103 14612723503 0014244 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	6	2024-04-02	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-02 15:46:04.30779	\N
2	10	2024-04-02	1	13     	2	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-02 19:01:34.096924	\N
3	7	2024-04-02	1	01     	3	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-02 19:04:31.723126	\N
4	2	2024-04-05	1	0      	2	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-03 16:19:40.767217	\N
5	10	2024-04-06	1	\N	2	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-03 16:20:04.038445	\N
6	10	2024-04-06	1	\N	2	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-03 16:20:39.684037	\N
7	10	2024-04-06	1	\N	2	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-03 16:21:14.088144	\N
8	4	2024-04-03	1	\N	2	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-03 16:28:24.108821	\N
9	4	2024-04-03	1	\N	2	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-03 16:34:06.017245	\N
10	1	2024-04-03	1	\N	2	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-03 16:37:32.054372	\N
11	2	2024-04-03	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-03 16:55:24.410354	\N
12	4	0001-01-05	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-03 17:10:43.019296	\N
13	6	2024-04-03	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-03 17:15:02.803573	\N
14	10	2024-04-02	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-04 17:47:03.916224	\N
15	1	2024-04-04	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-04 18:41:25.565566	\N
16	2	2024-04-04	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-04 18:50:46.056742	\N
17	2	2024-04-03	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-04 19:08:58.082016	\N
18	2	2024-04-02	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-05 12:10:26.831353	\N
19	6	2024-04-06	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-05 15:29:18.213335	\N
20	7	2024-05-08	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-08 09:59:30.877785	\N
21	6	2024-04-08	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-08 14:24:13.406525	\N
22	7	2024-04-09	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:15:23.277408	\N
23	4	2024-04-09	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:15:37.667554	\N
24	1	2024-04-09	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:37:08.261646	\N
25	10	2024-04-09	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:38:57.319075	\N
26	7	2024-04-09	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 19:01:21.951761	\N
27	7	2024-04-16	0	\N	0	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-16 16:21:54.295586	\N
28	7	2024-04-19	0	\N	0	d760793e-a336-44b8-8f5c-27a7be2d8f52	2024-04-17 14:11:57.696732	\N
31	12	2024-04-26	0	\N	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 12:18:34.815625	\N
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                             5221.dat                                                                                            0000600 0004000 0002000 00000006664 14612723503 0014262 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        3	2	2024-04-08 00:00:00	3	05:00:00	06:00:00	1	1	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-08 15:53:37.438648	\N	\N	\N
15	4	2024-04-07 00:00:00	2	01:00:00	02:00:00	1	1	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-08 16:09:38.49458	\N	\N	\N
27	15	2024-04-04 00:00:00	1	22:00:00	23:00:00	0	1	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-08 16:19:11.207487	\N	\N	\N
8	3	2024-04-07 00:00:00	3	06:00:00	07:15:00	1	0	\N	\N	\N	\N	\N
17	5	2024-04-06 00:00:00	3	03:00:00	04:00:00	1	0	\N	\N	\N	\N	\N
31	19	2024-04-06 00:00:00	2	01:00:00	02:00:00	1	0	\N	\N	\N	\N	\N
14	4	2024-04-05 00:00:00	2	01:00:00	02:00:00	1	0	\N	\N	\N	\N	\N
25	13	2024-04-03 00:00:00	2	10:00:00	12:00:00	1	0	\N	\N	\N	\N	\N
22	10	2024-04-03 00:00:00	1	02:00:00	03:04:00	1	0	\N	\N	\N	\N	\N
7	3	2024-04-02 00:00:00	3	06:00:00	07:15:00	1	0	\N	\N	\N	\N	\N
1	1	2024-04-02 00:00:00	2	01:02:00	02:00:00	1	0	\N	\N	\N	\N	\N
19	7	2024-04-06 00:00:00	3	07:00:00	08:00:00	1	0	\N	\N	\N	\N	\N
5	2	2024-04-03 00:00:00	3	04:00:00	05:00:00	1	0	\N	\N	\N	\N	\N
20	8	2024-04-03 00:00:00	1	06:00:00	08:00:00	1	0	\N	\N	\N	\N	\N
23	11	2024-04-03 00:00:00	2	05:05:00	06:01:00	1	0	\N	\N	\N	\N	\N
26	14	2024-04-02 00:00:00	3	07:00:00	08:00:00	1	0	\N	\N	\N	\N	\N
28	16	2024-04-04 00:00:00	2	01:00:00	02:00:00	1	0	\N	\N	\N	\N	\N
30	18	2024-04-02 00:00:00	2	21:00:00	22:00:00	1	0	\N	\N	\N	\N	\N
18	6	2024-04-06 00:00:00	3	05:00:00	06:00:00	1	0	\N	\N	\N	\N	\N
24	12	2024-04-05 00:00:00	1	19:00:00	21:00:00	1	0	\N	\N	\N	\N	\N
21	9	2024-04-03 00:00:00	1	09:00:00	11:00:00	1	0	\N	\N	\N	\N	\N
29	17	2024-04-03 00:00:00	2	21:00:00	22:00:00	1	0	\N	\N	\N	\N	\N
2	2	2024-04-02 00:00:00	3	05:00:00	06:00:00	1	0	\N	\N	\N	\N	\N
32	20	2024-05-08 00:00:00	3	01:00:00	02:00:00	1	0	\N	\N	\N	\N	\N
33	21	2024-04-09 00:00:00	2	13:00:00	14:03:00	1	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 13:24:03.985864	\N	\N	\N
4	2	2024-04-15 00:00:00	3	05:00:00	06:00:00	0	1	\N	\N	\N	\N	\N
6	2	2024-04-10 00:00:00	3	03:00:00	04:00:00	0	1	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-08 18:24:06.20282	\N	\N	\N
12	3	2024-04-15 00:00:00	3	06:00:00	07:15:00	0	1	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:05:35.668267	\N	\N	\N
10	3	2024-04-21 00:00:00	3	06:00:00	07:15:00	0	1	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:09:41.303426	\N	\N	\N
9	3	2024-04-14 00:00:00	3	06:00:00	07:15:00	0	1	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:14:18.186991	\N	\N	\N
11	3	2024-04-08 00:00:00	3	06:00:00	07:15:00	1	1	\N	\N	\N	\N	\N
13	3	2024-04-22 00:00:00	3	06:00:00	07:15:00	1	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:14:28.333312	\N	\N	\N
34	22	2024-04-09 00:00:00	3	01:00:00	02:00:00	1	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:34:23.511825	\N	\N	\N
16	4	2024-04-14 00:00:00	2	01:00:00	02:00:00	1	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:35:27.442003	\N	\N	\N
36	24	2024-04-09 00:00:00	1	04:00:00	05:00:00	1	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:37:13.770136	\N	\N	\N
37	25	2024-04-09 00:00:00	3	04:00:00	05:00:00	1	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 18:39:02.850863	\N	\N	\N
35	23	2024-04-09 00:00:00	1	04:00:00	05:00:00	1	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-09 19:00:56.306341	\N	\N	\N
38	26	2024-04-09 00:00:00	3	03:00:00	04:00:00	0	0	\N	\N	\N	\N	\N
39	27	2024-04-16 00:00:00	3	01:00:00	02:00:00	0	0	\N	\N	\N	\N	\N
40	28	2024-04-19 00:00:00	3	01:00:00	02:00:00	0	0	\N	\N	\N	\N	\N
43	31	2024-04-26 00:00:00	3	01:00:00	02:00:00	1	0	21c57981-a679-4b62-8eee-57c1ce429643	2024-04-26 17:43:32.916514	\N	\N	\N
\.


                                                                            5222.dat                                                                                            0000600 0004000 0002000 00000000005 14612723503 0014242 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           5226.dat                                                                                            0000600 0004000 0002000 00000002335 14612723503 0014256 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        9	21c57981-a679-4b62-8eee-57c1ce429643	test	test1	demo@gmail.com	999999999	\N	demostreet	rajkot	gujrat	2	877834	Feb	2024	9	Patient	2024-02-15 12:29:39.340468	\N	\N	\N	\N	\N	\N
1	a86d721c-b1e0-4284-a5c1-7e5a7ffd6b87	asdfa	asdsadsa	nikul123@gmail.com	8346787687	\N	k2, surat	snagar	snagar	\N	343424	Apr	2024	12	a86d721c-b1e0-4284-a5c1-7e5a7ffd6b87	2024-04-21 15:45:06.215778	\N	\N	\N	\N	\N	\N
2	2784cd86-9433-4e5e-8889-60ef80690b79	jaydeep	test	jaydeep123@gmail.com	9566766534	\N	b1	surat	surat	3	349493	Apr	2024	12	2784cd86-9433-4e5e-8889-60ef80690b79	2024-04-21 17:52:49.413246	\N	\N	\N	\N	\N	\N
6	5d2e6b2d-bd70-4f99-ae34-6cbe2dfe9a9a	tatvasoftnew	soft	x@gmail.com	9876651234	1	streetdemo	rajkot	gujrat	1	343434	Mar	2024	1	Patient	2024-02-09 16:32:09.912932	\N	2024-04-23 22:16:23.833818	\N	\N	\N	\N
3	7ffa72f6-546f-4c1b-aa25-56e7f1261a2a	demotest	demotesting	demo123@gmail.com	9999967897	\N	k2, surat	snagar	surat	\N	343424	Apr	2024	18	7ffa72f6-546f-4c1b-aa25-56e7f1261a2a	2024-04-23 23:08:50.322388	\N	\N	\N	\N	\N	\N
4	5b8b641b-0ed0-4599-a1e8-c2d226079a7b	saurav	patel	aniyariyavijay441@gmail.com	9898989989	\N	teststreet	surat	surat	\N	385667	Apr	2024	20	5b8b641b-0ed0-4599-a1e8-c2d226079a7b	2024-04-26 14:48:37.774572	\N	\N	\N	\N	\N	\N
\.


                                                                                                                                                                                                                                                                                                   restore.sql                                                                                         0000600 0004000 0002000 00000254570 14612723503 0015404 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 16.1
-- Dumped by pg_dump version 16.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "HalloDocMVC";
--
-- Name: HalloDocMVC; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "HalloDocMVC" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';


ALTER DATABASE "HalloDocMVC" OWNER TO postgres;

\connect "HalloDocMVC"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Admin; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Admin" (
    "AdminId" integer NOT NULL,
    "AspNetUserId" character varying(128) NOT NULL,
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(100),
    "RegionId" integer,
    "Zip" character varying(10),
    "AltPhone" character varying(20),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" bit(1),
    "RoleId" integer
);


ALTER TABLE public."Admin" OWNER TO postgres;

--
-- Name: AdminRegion; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AdminRegion" (
    "AdminRegionId" integer NOT NULL,
    "AdminId" integer NOT NULL,
    "RegionId" integer NOT NULL
);


ALTER TABLE public."AdminRegion" OWNER TO postgres;

--
-- Name: AdminRegion_AdminRegionId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."AdminRegion_AdminRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."AdminRegion_AdminRegionId_seq" OWNER TO postgres;

--
-- Name: AdminRegion_AdminRegionId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."AdminRegion_AdminRegionId_seq" OWNED BY public."AdminRegion"."AdminRegionId";


--
-- Name: Admin_AdminId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Admin_AdminId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Admin_AdminId_seq" OWNER TO postgres;

--
-- Name: Admin_AdminId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Admin_AdminId_seq" OWNED BY public."Admin"."AdminId";


--
-- Name: AspNetRoles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetRoles" (
    "Id" character varying(128) NOT NULL,
    "Name" character varying(256) NOT NULL
);


ALTER TABLE public."AspNetRoles" OWNER TO postgres;

--
-- Name: AspNetUserRoles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUserRoles" (
    "UserId" character varying(128) NOT NULL,
    "RoleId" character varying(128) NOT NULL
);


ALTER TABLE public."AspNetUserRoles" OWNER TO postgres;

--
-- Name: AspNetUsers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUsers" (
    "Id" character varying(128) NOT NULL,
    "UserName" character varying(256) NOT NULL,
    "PasswordHash" character varying,
    "Email" character varying(256),
    "PhoneNumber" character varying(20),
    "IP" character varying(20),
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedDate" timestamp without time zone
);


ALTER TABLE public."AspNetUsers" OWNER TO postgres;

--
-- Name: BlockRequests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."BlockRequests" (
    "BlockRequestId" integer NOT NULL,
    "PhoneNumber" character varying(50),
    "Email" character varying(50),
    "IsActive" bit(1),
    "Reason" character varying,
    "RequestId" character varying NOT NULL,
    "IP" character varying(20),
    "CreatedDate" timestamp without time zone,
    "ModifiedDate" timestamp without time zone
);


ALTER TABLE public."BlockRequests" OWNER TO postgres;

--
-- Name: BlockRequests_BlockRequestId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."BlockRequests_BlockRequestId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."BlockRequests_BlockRequestId_seq" OWNER TO postgres;

--
-- Name: BlockRequests_BlockRequestId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."BlockRequests_BlockRequestId_seq" OWNED BY public."BlockRequests"."BlockRequestId";


--
-- Name: Business; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Business" (
    "BusinessId" integer NOT NULL,
    "Name" character varying(100) NOT NULL,
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(50),
    "RegionId" integer,
    "ZipCode" character varying(10),
    "PhoneNumber" character varying(20),
    "FaxNumber" character varying(20),
    "IsRegistered" bit(1),
    "CreatedBy" character varying(128),
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" bit(1),
    "IP" character varying(20)
);


ALTER TABLE public."Business" OWNER TO postgres;

--
-- Name: Business_BusinessId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Business_BusinessId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Business_BusinessId_seq" OWNER TO postgres;

--
-- Name: Business_BusinessId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Business_BusinessId_seq" OWNED BY public."Business"."BusinessId";


--
-- Name: CaseTag; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."CaseTag" (
    "CaseTagId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);


ALTER TABLE public."CaseTag" OWNER TO postgres;

--
-- Name: CaseTag_CaseTagId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."CaseTag_CaseTagId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."CaseTag_CaseTagId_seq" OWNER TO postgres;

--
-- Name: CaseTag_CaseTagId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."CaseTag_CaseTagId_seq" OWNED BY public."CaseTag"."CaseTagId";


--
-- Name: Concierge; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Concierge" (
    "ConciergeId" integer NOT NULL,
    "ConciergeName" character varying(100) NOT NULL,
    "Address" character varying(150),
    "Street" character varying(50) NOT NULL,
    "City" character varying(50) NOT NULL,
    "State" character varying(50) NOT NULL,
    "ZipCode" character varying(50) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "RegionId" integer NOT NULL,
    "RoleId" character varying(20)
);


ALTER TABLE public."Concierge" OWNER TO postgres;

--
-- Name: Concierge_ConciergeId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Concierge_ConciergeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Concierge_ConciergeId_seq" OWNER TO postgres;

--
-- Name: Concierge_ConciergeId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Concierge_ConciergeId_seq" OWNED BY public."Concierge"."ConciergeId";


--
-- Name: EmailLog; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."EmailLog" (
    "EmailLogID" integer NOT NULL,
    "EmailTemplate" character varying NOT NULL,
    "SubjectName" character varying(200) NOT NULL,
    "EmailID" character varying(200) NOT NULL,
    "ConfirmationNumber" character varying(200),
    "FilePath" character varying,
    "RoleId" integer,
    "RequestId" integer,
    "AdminId" integer,
    "PhysicianId" integer,
    "CreateDate" timestamp without time zone NOT NULL,
    "SentDate" timestamp without time zone,
    "IsEmailSent" bit(1),
    "SentTries" integer,
    "Action" integer
);


ALTER TABLE public."EmailLog" OWNER TO postgres;

--
-- Name: EmailLog_EmailLogID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."EmailLog" ALTER COLUMN "EmailLogID" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."EmailLog_EmailLogID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: EncounterForm; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."EncounterForm" (
    "EncounterFormId" integer NOT NULL,
    "RequestId" integer,
    "HistoryOfPresentIllnessOrInjury" text,
    "MedicalHistory" text,
    "Medications" text,
    "Allergies" text,
    "Temp" text,
    "HR" text,
    "RR" text,
    "BloodPressureSystolic" text,
    "BloodPressureDiastolic" text,
    "O2" text,
    "Pain" text,
    "Heent" text,
    "CV" text,
    "Chest" text,
    "ABD" text,
    "Extremeties" text,
    "Skin" text,
    "Neuro" text,
    "Other" text,
    "Diagnosis" text,
    "TreatmentPlan" text,
    "MedicationsDispensed" text,
    "Procedures" text,
    "FollowUp" text,
    "AdminId" integer,
    "PhysicianId" integer,
    "IsFinalize" boolean DEFAULT false NOT NULL
);


ALTER TABLE public."EncounterForm" OWNER TO postgres;

--
-- Name: EncounterForm_EncounterFormId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."EncounterForm_EncounterFormId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."EncounterForm_EncounterFormId_seq" OWNER TO postgres;

--
-- Name: EncounterForm_EncounterFormId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."EncounterForm_EncounterFormId_seq" OWNED BY public."EncounterForm"."EncounterFormId";


--
-- Name: HealthProfessionalType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."HealthProfessionalType" (
    "HealthProfessionalId" integer NOT NULL,
    "ProfessionName" character varying(50) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "IsActive" bit(1),
    "IsDeleted" bit(1)
);


ALTER TABLE public."HealthProfessionalType" OWNER TO postgres;

--
-- Name: HealthProfessionalType_HealthProfessionalId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq" OWNER TO postgres;

--
-- Name: HealthProfessionalType_HealthProfessionalId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq" OWNED BY public."HealthProfessionalType"."HealthProfessionalId";


--
-- Name: HealthProfessionals; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."HealthProfessionals" (
    "VendorId" integer NOT NULL,
    "VendorName" character varying(100) NOT NULL,
    "Profession" integer,
    "FaxNumber" character varying(50) NOT NULL,
    "Address" character varying(150),
    "City" character varying(100),
    "State" character varying(50),
    "Zip" character varying(50),
    "RegionId" integer,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedDate" timestamp without time zone,
    "PhoneNumber" character varying(100),
    "IsDeleted" bit(1),
    "IP" character varying(20),
    "Email" character varying(50),
    "BusinessContact" character varying(100)
);


ALTER TABLE public."HealthProfessionals" OWNER TO postgres;

--
-- Name: HealthProfessionals_VendorId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."HealthProfessionals_VendorId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."HealthProfessionals_VendorId_seq" OWNER TO postgres;

--
-- Name: HealthProfessionals_VendorId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."HealthProfessionals_VendorId_seq" OWNED BY public."HealthProfessionals"."VendorId";


--
-- Name: Menu; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Menu" (
    "MenuId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "AccountType" smallint NOT NULL,
    "SortOrder" integer
);


ALTER TABLE public."Menu" OWNER TO postgres;

--
-- Name: Menu_MenuId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Menu_MenuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Menu_MenuId_seq" OWNER TO postgres;

--
-- Name: Menu_MenuId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Menu_MenuId_seq" OWNED BY public."Menu"."MenuId";


--
-- Name: OrderDetails; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."OrderDetails" (
    "Id" integer NOT NULL,
    "VendorId" integer,
    "RequestId" integer,
    "FaxNumber" character varying(50),
    "Email" character varying(50),
    "BusinessContact" character varying(100),
    "Prescription" character varying,
    "NoOfRefill" integer,
    "CreatedDate" timestamp without time zone,
    "CreatedBy" character varying(100)
);


ALTER TABLE public."OrderDetails" OWNER TO postgres;

--
-- Name: OrderDetails_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."OrderDetails_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."OrderDetails_Id_seq" OWNER TO postgres;

--
-- Name: OrderDetails_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."OrderDetails_Id_seq" OWNED BY public."OrderDetails"."Id";


--
-- Name: Physician; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Physician" (
    "PhysicianId" integer NOT NULL,
    "AspNetUserId" character varying(128),
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "MedicalLicense" character varying(500),
    "Photo" character varying(100),
    "AdminNotes" character varying(500),
    "IsAgreementDoc" bit(1),
    "IsBackgroundDoc" bit(1),
    "IsTrainingDoc" bit(1),
    "IsNonDisclosureDoc" bit(1),
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(100),
    "RegionId" integer,
    "Zip" character varying(10),
    "AltPhone" character varying(20),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "BusinessName" character varying(100) NOT NULL,
    "BusinessWebsite" character varying(200) NOT NULL,
    "IsDeleted" bit(1),
    "RoleId" integer,
    "NPINumber" character varying(500),
    "IsLicenseDoc" bit(1),
    "Signature" character varying(100),
    "IsCredentialDoc" bit(1),
    "IsTokenGenerate" bit(1),
    "SyncEmailAddress" character varying(50)
);


ALTER TABLE public."Physician" OWNER TO postgres;

--
-- Name: PhysicianLocation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PhysicianLocation" (
    "LocationId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "Latitude" numeric(11,8),
    "Longitude" numeric(11,8),
    "CreatedDate" timestamp without time zone,
    "PhysicianName" character varying(50),
    "Address" character varying(500)
);


ALTER TABLE public."PhysicianLocation" OWNER TO postgres;

--
-- Name: PhysicianLocation_LocationId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."PhysicianLocation_LocationId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."PhysicianLocation_LocationId_seq" OWNER TO postgres;

--
-- Name: PhysicianLocation_LocationId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."PhysicianLocation_LocationId_seq" OWNED BY public."PhysicianLocation"."LocationId";


--
-- Name: PhysicianNotification; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PhysicianNotification" (
    id integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "IsNotificationStopped" bit(1) NOT NULL
);


ALTER TABLE public."PhysicianNotification" OWNER TO postgres;

--
-- Name: PhysicianNotification_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."PhysicianNotification_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."PhysicianNotification_id_seq" OWNER TO postgres;

--
-- Name: PhysicianNotification_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."PhysicianNotification_id_seq" OWNED BY public."PhysicianNotification".id;


--
-- Name: PhysicianRegion; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PhysicianRegion" (
    "PhysicianRegionId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "RegionId" integer NOT NULL
);


ALTER TABLE public."PhysicianRegion" OWNER TO postgres;

--
-- Name: PhysicianRegion_PhysicianRegionId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq" OWNER TO postgres;

--
-- Name: PhysicianRegion_PhysicianRegionId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq" OWNED BY public."PhysicianRegion"."PhysicianRegionId";


--
-- Name: Physician_PhysicianId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Physician_PhysicianId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Physician_PhysicianId_seq" OWNER TO postgres;

--
-- Name: Physician_PhysicianId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Physician_PhysicianId_seq" OWNED BY public."Physician"."PhysicianId";


--
-- Name: Region; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Region" (
    "RegionId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Abbreviation" character varying(50)
);


ALTER TABLE public."Region" OWNER TO postgres;

--
-- Name: Region_RegionId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Region_RegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Region_RegionId_seq" OWNER TO postgres;

--
-- Name: Region_RegionId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Region_RegionId_seq" OWNED BY public."Region"."RegionId";


--
-- Name: Request; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Request" (
    "RequestId" integer NOT NULL,
    "RequestTypeId" integer NOT NULL,
    "UserId" integer,
    "FirstName" character varying(100),
    "LastName" character varying(100),
    "PhoneNumber" character varying(23),
    "Email" character varying(50),
    "Status" smallint NOT NULL,
    "PhysicianId" integer,
    "ConfirmationNumber" character varying(20),
    "CreatedDate" timestamp without time zone NOT NULL,
    "IsDeleted" bit(1),
    "ModifiedDate" timestamp without time zone,
    "DeclinedBy" character varying(250),
    "IsUrgentEmailSent" bit(1) NOT NULL,
    "LastWellnessDate" timestamp without time zone,
    "IsMobile" bit(1),
    "CallType" smallint,
    "CompletedByPhysician" bit(1),
    "LastReservationDate" timestamp without time zone,
    "AcceptedDate" timestamp without time zone,
    "RelationName" character varying(100),
    "CaseNumber" character varying(50),
    "IP" character varying(20),
    "CaseTag" character varying(50),
    "CaseTagPhysician" character varying(50),
    "PatientAccountId" character varying(128),
    "CreatedUserId" integer,
    CONSTRAINT "Request_RequestTypeId_check" CHECK (("RequestTypeId" = ANY (ARRAY[1, 2, 3, 4]))),
    CONSTRAINT "Request_Status_check" CHECK (("Status" = ANY (ARRAY[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15])))
);


ALTER TABLE public."Request" OWNER TO postgres;

--
-- Name: RequestBusiness; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestBusiness" (
    "RequestBusinessId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "BusinessId" integer NOT NULL,
    "IP" character varying(20)
);


ALTER TABLE public."RequestBusiness" OWNER TO postgres;

--
-- Name: RequestBusiness_RequestBusinessId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestBusiness_RequestBusinessId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestBusiness_RequestBusinessId_seq" OWNER TO postgres;

--
-- Name: RequestBusiness_RequestBusinessId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestBusiness_RequestBusinessId_seq" OWNED BY public."RequestBusiness"."RequestBusinessId";


--
-- Name: RequestClient; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestClient" (
    "RequestClientId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "PhoneNumber" character varying(23),
    "Location" character varying(100),
    "Address" character varying(500),
    "RegionId" integer,
    "NotiMobile" character varying(20),
    "NotiEmail" character varying(50),
    "Notes" character varying(500),
    "Email" character varying(50),
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "IsMobile" bit(1),
    "Street" character varying(100),
    "City" character varying(100),
    "State" character varying(100),
    "ZipCode" character varying(10),
    "CommunicationType" smallint,
    "RemindReservationCount" smallint,
    "RemindHouseCallCount" smallint,
    "IsSetFollowupSent" smallint,
    "IP" character varying(20),
    "IsReservationReminderSent" smallint,
    "Latitude" numeric(11,8),
    "Longitude" numeric(11,8)
);


ALTER TABLE public."RequestClient" OWNER TO postgres;

--
-- Name: RequestClient_RequestClientId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestClient_RequestClientId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestClient_RequestClientId_seq" OWNER TO postgres;

--
-- Name: RequestClient_RequestClientId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestClient_RequestClientId_seq" OWNED BY public."RequestClient"."RequestClientId";


--
-- Name: RequestClosed; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestClosed" (
    "RequestClosedId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "RequestStatusLogId" integer NOT NULL,
    "PhyNotes" character varying(500),
    "ClientNotes" character varying(500),
    "IP" character varying(20)
);


ALTER TABLE public."RequestClosed" OWNER TO postgres;

--
-- Name: RequestClosed_RequestClosedId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestClosed_RequestClosedId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestClosed_RequestClosedId_seq" OWNER TO postgres;

--
-- Name: RequestClosed_RequestClosedId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestClosed_RequestClosedId_seq" OWNED BY public."RequestClosed"."RequestClosedId";


--
-- Name: RequestConcierge; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestConcierge" (
    "Id" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "ConciergeId" integer NOT NULL,
    "IP" character varying(20)
);


ALTER TABLE public."RequestConcierge" OWNER TO postgres;

--
-- Name: RequestConcierge_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestConcierge_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestConcierge_Id_seq" OWNER TO postgres;

--
-- Name: RequestConcierge_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestConcierge_Id_seq" OWNED BY public."RequestConcierge"."Id";


--
-- Name: RequestNotes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestNotes" (
    "RequestNotesId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "PhysicianNotes" character varying(500),
    "AdminNotes" character varying(500),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "IP" character varying(20),
    "AdministrativeNotes" character varying(500)
);


ALTER TABLE public."RequestNotes" OWNER TO postgres;

--
-- Name: RequestNotes_RequestNotesId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestNotes_RequestNotesId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestNotes_RequestNotesId_seq" OWNER TO postgres;

--
-- Name: RequestNotes_RequestNotesId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestNotes_RequestNotesId_seq" OWNED BY public."RequestNotes"."RequestNotesId";


--
-- Name: RequestStatusLog; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestStatusLog" (
    "RequestStatusLogId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "Status" smallint NOT NULL,
    "PhysicianId" integer,
    "AdminId" integer,
    "TransToPhysicianId" integer,
    "Notes" character varying(500),
    "CreatedDate" timestamp without time zone NOT NULL,
    "IP" character varying(20),
    "TransToAdmin" bit(1)
);


ALTER TABLE public."RequestStatusLog" OWNER TO postgres;

--
-- Name: RequestStatusLog_RequestStatusLogId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq" OWNER TO postgres;

--
-- Name: RequestStatusLog_RequestStatusLogId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq" OWNED BY public."RequestStatusLog"."RequestStatusLogId";


--
-- Name: RequestType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestType" (
    "RequestTypeId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);


ALTER TABLE public."RequestType" OWNER TO postgres;

--
-- Name: RequestType_RequestTypeId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestType_RequestTypeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestType_RequestTypeId_seq" OWNER TO postgres;

--
-- Name: RequestType_RequestTypeId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestType_RequestTypeId_seq" OWNED BY public."RequestType"."RequestTypeId";


--
-- Name: RequestWiseFile; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RequestWiseFile" (
    "RequestWiseFileID" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "FileName" character varying(500) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "PhysicianId" integer,
    "AdminId" integer,
    "DocType" smallint,
    "IsFrontSide" bit(1),
    "IsCompensation" bit(1),
    "IP" character varying(20),
    "IsFinalize" bit(1),
    "IsDeleted" bit(1),
    "IsPatientRecords" bit(1),
    CONSTRAINT "RequestWiseFile_DocType_check" CHECK (("DocType" = ANY (ARRAY[1, 2, 3])))
);


ALTER TABLE public."RequestWiseFile" OWNER TO postgres;

--
-- Name: RequestWiseFile_RequestWiseFileID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq" OWNER TO postgres;

--
-- Name: RequestWiseFile_RequestWiseFileID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq" OWNED BY public."RequestWiseFile"."RequestWiseFileID";


--
-- Name: Request_RequestId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Request_RequestId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Request_RequestId_seq" OWNER TO postgres;

--
-- Name: Request_RequestId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Request_RequestId_seq" OWNED BY public."Request"."RequestId";


--
-- Name: Role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Role" (
    "RoleId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "IsDeleted" bit(1) NOT NULL,
    "IP" character varying(20),
    "AccountType" smallint DEFAULT 1 NOT NULL,
    CONSTRAINT "Role_AccountType_check" CHECK (("AccountType" = ANY (ARRAY[1, 2, 3, 4])))
);


ALTER TABLE public."Role" OWNER TO postgres;

--
-- Name: RoleMenu; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RoleMenu" (
    "RoleMenuId" integer NOT NULL,
    "RoleId" integer NOT NULL,
    "MenuId" integer NOT NULL
);


ALTER TABLE public."RoleMenu" OWNER TO postgres;

--
-- Name: RoleMenu_RoleMenuId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RoleMenu_RoleMenuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RoleMenu_RoleMenuId_seq" OWNER TO postgres;

--
-- Name: RoleMenu_RoleMenuId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RoleMenu_RoleMenuId_seq" OWNED BY public."RoleMenu"."RoleMenuId";


--
-- Name: Role_RoleId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Role_RoleId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Role_RoleId_seq" OWNER TO postgres;

--
-- Name: Role_RoleId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Role_RoleId_seq" OWNED BY public."Role"."RoleId";


--
-- Name: SMSLog; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."SMSLog" (
    "SMSLogID" integer NOT NULL,
    "SMSTemplate" character varying NOT NULL,
    "MobileNumber" character varying(50) NOT NULL,
    "ConfirmationNumber" character varying(200),
    "RoleId" integer,
    "AdminId" integer,
    "RequestId" integer,
    "PhysicianId" integer,
    "CreateDate" timestamp without time zone NOT NULL,
    "SentDate" timestamp without time zone,
    "IsSMSSent" bit(1),
    "SentTries" integer NOT NULL,
    "Action" integer
);


ALTER TABLE public."SMSLog" OWNER TO postgres;

--
-- Name: SMSLog_SMSLogID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."SMSLog" ALTER COLUMN "SMSLogID" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."SMSLog_SMSLogID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Shift; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Shift" (
    "ShiftId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "StartDate" date NOT NULL,
    "IsRepeat" bit(1) NOT NULL,
    "WeekDays" character(7),
    "RepeatUpto" integer,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "IP" character varying(20)
);


ALTER TABLE public."Shift" OWNER TO postgres;

--
-- Name: ShiftDetail; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ShiftDetail" (
    "ShiftDetailId" integer NOT NULL,
    "ShiftId" integer NOT NULL,
    "ShiftDate" timestamp without time zone NOT NULL,
    "RegionId" integer,
    "StartTime" time without time zone NOT NULL,
    "EndTime" time without time zone NOT NULL,
    "Status" smallint NOT NULL,
    "IsDeleted" bit(1) NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "LastRunningDate" timestamp without time zone,
    "EventId" character varying(100),
    "IsSync" bit(1)
);


ALTER TABLE public."ShiftDetail" OWNER TO postgres;

--
-- Name: ShiftDetailRegion; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ShiftDetailRegion" (
    "ShiftDetailRegionId" integer NOT NULL,
    "ShiftDetailId" integer NOT NULL,
    "RegionId" integer NOT NULL,
    "IsDeleted" bit(1)
);


ALTER TABLE public."ShiftDetailRegion" OWNER TO postgres;

--
-- Name: ShiftDetailRegion_ShiftDetailRegionId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq" OWNER TO postgres;

--
-- Name: ShiftDetailRegion_ShiftDetailRegionId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq" OWNED BY public."ShiftDetailRegion"."ShiftDetailRegionId";


--
-- Name: ShiftDetail_ShiftDetailId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ShiftDetail_ShiftDetailId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."ShiftDetail_ShiftDetailId_seq" OWNER TO postgres;

--
-- Name: ShiftDetail_ShiftDetailId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ShiftDetail_ShiftDetailId_seq" OWNED BY public."ShiftDetail"."ShiftDetailId";


--
-- Name: Shift_ShiftId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Shift_ShiftId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Shift_ShiftId_seq" OWNER TO postgres;

--
-- Name: Shift_ShiftId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Shift_ShiftId_seq" OWNED BY public."Shift"."ShiftId";


--
-- Name: User; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."User" (
    "UserId" integer NOT NULL,
    "AspNetUserId" character varying(128),
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "IsMobile" bit(1),
    "Street" character varying(100),
    "City" character varying(100),
    "State" character varying(100),
    "RegionId" integer,
    "ZipCode" character varying(10),
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" bit(1),
    "IP" character varying(20),
    "IsRequestWithEmail" bit(1)
);


ALTER TABLE public."User" OWNER TO postgres;

--
-- Name: User_UserId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."User" ALTER COLUMN "UserId" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."User_UserId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Admin AdminId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Admin" ALTER COLUMN "AdminId" SET DEFAULT nextval('public."Admin_AdminId_seq"'::regclass);


--
-- Name: AdminRegion AdminRegionId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AdminRegion" ALTER COLUMN "AdminRegionId" SET DEFAULT nextval('public."AdminRegion_AdminRegionId_seq"'::regclass);


--
-- Name: BlockRequests BlockRequestId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BlockRequests" ALTER COLUMN "BlockRequestId" SET DEFAULT nextval('public."BlockRequests_BlockRequestId_seq"'::regclass);


--
-- Name: Business BusinessId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Business" ALTER COLUMN "BusinessId" SET DEFAULT nextval('public."Business_BusinessId_seq"'::regclass);


--
-- Name: CaseTag CaseTagId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."CaseTag" ALTER COLUMN "CaseTagId" SET DEFAULT nextval('public."CaseTag_CaseTagId_seq"'::regclass);


--
-- Name: Concierge ConciergeId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Concierge" ALTER COLUMN "ConciergeId" SET DEFAULT nextval('public."Concierge_ConciergeId_seq"'::regclass);


--
-- Name: EncounterForm EncounterFormId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EncounterForm" ALTER COLUMN "EncounterFormId" SET DEFAULT nextval('public."EncounterForm_EncounterFormId_seq"'::regclass);


--
-- Name: HealthProfessionalType HealthProfessionalId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HealthProfessionalType" ALTER COLUMN "HealthProfessionalId" SET DEFAULT nextval('public."HealthProfessionalType_HealthProfessionalId_seq"'::regclass);


--
-- Name: HealthProfessionals VendorId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HealthProfessionals" ALTER COLUMN "VendorId" SET DEFAULT nextval('public."HealthProfessionals_VendorId_seq"'::regclass);


--
-- Name: Menu MenuId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Menu" ALTER COLUMN "MenuId" SET DEFAULT nextval('public."Menu_MenuId_seq"'::regclass);


--
-- Name: OrderDetails Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderDetails" ALTER COLUMN "Id" SET DEFAULT nextval('public."OrderDetails_Id_seq"'::regclass);


--
-- Name: Physician PhysicianId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Physician" ALTER COLUMN "PhysicianId" SET DEFAULT nextval('public."Physician_PhysicianId_seq"'::regclass);


--
-- Name: PhysicianLocation LocationId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianLocation" ALTER COLUMN "LocationId" SET DEFAULT nextval('public."PhysicianLocation_LocationId_seq"'::regclass);


--
-- Name: PhysicianNotification id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianNotification" ALTER COLUMN id SET DEFAULT nextval('public."PhysicianNotification_id_seq"'::regclass);


--
-- Name: PhysicianRegion PhysicianRegionId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianRegion" ALTER COLUMN "PhysicianRegionId" SET DEFAULT nextval('public."PhysicianRegion_PhysicianRegionId_seq"'::regclass);


--
-- Name: Region RegionId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Region" ALTER COLUMN "RegionId" SET DEFAULT nextval('public."Region_RegionId_seq"'::regclass);


--
-- Name: Request RequestId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request" ALTER COLUMN "RequestId" SET DEFAULT nextval('public."Request_RequestId_seq"'::regclass);


--
-- Name: RequestBusiness RequestBusinessId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestBusiness" ALTER COLUMN "RequestBusinessId" SET DEFAULT nextval('public."RequestBusiness_RequestBusinessId_seq"'::regclass);


--
-- Name: RequestClient RequestClientId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClient" ALTER COLUMN "RequestClientId" SET DEFAULT nextval('public."RequestClient_RequestClientId_seq"'::regclass);


--
-- Name: RequestClosed RequestClosedId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClosed" ALTER COLUMN "RequestClosedId" SET DEFAULT nextval('public."RequestClosed_RequestClosedId_seq"'::regclass);


--
-- Name: RequestConcierge Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestConcierge" ALTER COLUMN "Id" SET DEFAULT nextval('public."RequestConcierge_Id_seq"'::regclass);


--
-- Name: RequestNotes RequestNotesId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestNotes" ALTER COLUMN "RequestNotesId" SET DEFAULT nextval('public."RequestNotes_RequestNotesId_seq"'::regclass);


--
-- Name: RequestStatusLog RequestStatusLogId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog" ALTER COLUMN "RequestStatusLogId" SET DEFAULT nextval('public."RequestStatusLog_RequestStatusLogId_seq"'::regclass);


--
-- Name: RequestType RequestTypeId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestType" ALTER COLUMN "RequestTypeId" SET DEFAULT nextval('public."RequestType_RequestTypeId_seq"'::regclass);


--
-- Name: RequestWiseFile RequestWiseFileID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestWiseFile" ALTER COLUMN "RequestWiseFileID" SET DEFAULT nextval('public."RequestWiseFile_RequestWiseFileID_seq"'::regclass);


--
-- Name: Role RoleId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role" ALTER COLUMN "RoleId" SET DEFAULT nextval('public."Role_RoleId_seq"'::regclass);


--
-- Name: RoleMenu RoleMenuId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMenu" ALTER COLUMN "RoleMenuId" SET DEFAULT nextval('public."RoleMenu_RoleMenuId_seq"'::regclass);


--
-- Name: Shift ShiftId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Shift" ALTER COLUMN "ShiftId" SET DEFAULT nextval('public."Shift_ShiftId_seq"'::regclass);


--
-- Name: ShiftDetail ShiftDetailId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetail" ALTER COLUMN "ShiftDetailId" SET DEFAULT nextval('public."ShiftDetail_ShiftDetailId_seq"'::regclass);


--
-- Name: ShiftDetailRegion ShiftDetailRegionId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetailRegion" ALTER COLUMN "ShiftDetailRegionId" SET DEFAULT nextval('public."ShiftDetailRegion_ShiftDetailRegionId_seq"'::regclass);


--
-- Data for Name: Admin; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Admin" ("AdminId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "RoleId") FROM stdin;
\.
COPY public."Admin" ("AdminId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "RoleId") FROM '$$PATH$$/5159.dat';

--
-- Data for Name: AdminRegion; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AdminRegion" ("AdminRegionId", "AdminId", "RegionId") FROM stdin;
\.
COPY public."AdminRegion" ("AdminRegionId", "AdminId", "RegionId") FROM '$$PATH$$/5160.dat';

--
-- Data for Name: AspNetRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetRoles" ("Id", "Name") FROM stdin;
\.
COPY public."AspNetRoles" ("Id", "Name") FROM '$$PATH$$/5163.dat';

--
-- Data for Name: AspNetUserRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
\.
COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM '$$PATH$$/5164.dat';

--
-- Data for Name: AspNetUsers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUsers" ("Id", "UserName", "PasswordHash", "Email", "PhoneNumber", "IP", "CreatedDate", "ModifiedDate") FROM stdin;
\.
COPY public."AspNetUsers" ("Id", "UserName", "PasswordHash", "Email", "PhoneNumber", "IP", "CreatedDate", "ModifiedDate") FROM '$$PATH$$/5165.dat';

--
-- Data for Name: BlockRequests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."BlockRequests" ("BlockRequestId", "PhoneNumber", "Email", "IsActive", "Reason", "RequestId", "IP", "CreatedDate", "ModifiedDate") FROM stdin;
\.
COPY public."BlockRequests" ("BlockRequestId", "PhoneNumber", "Email", "IsActive", "Reason", "RequestId", "IP", "CreatedDate", "ModifiedDate") FROM '$$PATH$$/5166.dat';

--
-- Data for Name: Business; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Business" ("BusinessId", "Name", "Address1", "Address2", "City", "RegionId", "ZipCode", "PhoneNumber", "FaxNumber", "IsRegistered", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP") FROM stdin;
\.
COPY public."Business" ("BusinessId", "Name", "Address1", "Address2", "City", "RegionId", "ZipCode", "PhoneNumber", "FaxNumber", "IsRegistered", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP") FROM '$$PATH$$/5168.dat';

--
-- Data for Name: CaseTag; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."CaseTag" ("CaseTagId", "Name") FROM stdin;
\.
COPY public."CaseTag" ("CaseTagId", "Name") FROM '$$PATH$$/5170.dat';

--
-- Data for Name: Concierge; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Concierge" ("ConciergeId", "ConciergeName", "Address", "Street", "City", "State", "ZipCode", "CreatedDate", "RegionId", "RoleId") FROM stdin;
\.
COPY public."Concierge" ("ConciergeId", "ConciergeName", "Address", "Street", "City", "State", "ZipCode", "CreatedDate", "RegionId", "RoleId") FROM '$$PATH$$/5172.dat';

--
-- Data for Name: EmailLog; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."EmailLog" ("EmailLogID", "EmailTemplate", "SubjectName", "EmailID", "ConfirmationNumber", "FilePath", "RoleId", "RequestId", "AdminId", "PhysicianId", "CreateDate", "SentDate", "IsEmailSent", "SentTries", "Action") FROM stdin;
\.
COPY public."EmailLog" ("EmailLogID", "EmailTemplate", "SubjectName", "EmailID", "ConfirmationNumber", "FilePath", "RoleId", "RequestId", "AdminId", "PhysicianId", "CreateDate", "SentDate", "IsEmailSent", "SentTries", "Action") FROM '$$PATH$$/5174.dat';

--
-- Data for Name: EncounterForm; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."EncounterForm" ("EncounterFormId", "RequestId", "HistoryOfPresentIllnessOrInjury", "MedicalHistory", "Medications", "Allergies", "Temp", "HR", "RR", "BloodPressureSystolic", "BloodPressureDiastolic", "O2", "Pain", "Heent", "CV", "Chest", "ABD", "Extremeties", "Skin", "Neuro", "Other", "Diagnosis", "TreatmentPlan", "MedicationsDispensed", "Procedures", "FollowUp", "AdminId", "PhysicianId", "IsFinalize") FROM stdin;
\.
COPY public."EncounterForm" ("EncounterFormId", "RequestId", "HistoryOfPresentIllnessOrInjury", "MedicalHistory", "Medications", "Allergies", "Temp", "HR", "RR", "BloodPressureSystolic", "BloodPressureDiastolic", "O2", "Pain", "Heent", "CV", "Chest", "ABD", "Extremeties", "Skin", "Neuro", "Other", "Diagnosis", "TreatmentPlan", "MedicationsDispensed", "Procedures", "FollowUp", "AdminId", "PhysicianId", "IsFinalize") FROM '$$PATH$$/5176.dat';

--
-- Data for Name: HealthProfessionalType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."HealthProfessionalType" ("HealthProfessionalId", "ProfessionName", "CreatedDate", "IsActive", "IsDeleted") FROM stdin;
\.
COPY public."HealthProfessionalType" ("HealthProfessionalId", "ProfessionName", "CreatedDate", "IsActive", "IsDeleted") FROM '$$PATH$$/5178.dat';

--
-- Data for Name: HealthProfessionals; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."HealthProfessionals" ("VendorId", "VendorName", "Profession", "FaxNumber", "Address", "City", "State", "Zip", "RegionId", "CreatedDate", "ModifiedDate", "PhoneNumber", "IsDeleted", "IP", "Email", "BusinessContact") FROM stdin;
\.
COPY public."HealthProfessionals" ("VendorId", "VendorName", "Profession", "FaxNumber", "Address", "City", "State", "Zip", "RegionId", "CreatedDate", "ModifiedDate", "PhoneNumber", "IsDeleted", "IP", "Email", "BusinessContact") FROM '$$PATH$$/5180.dat';

--
-- Data for Name: Menu; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Menu" ("MenuId", "Name", "AccountType", "SortOrder") FROM stdin;
\.
COPY public."Menu" ("MenuId", "Name", "AccountType", "SortOrder") FROM '$$PATH$$/5182.dat';

--
-- Data for Name: OrderDetails; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."OrderDetails" ("Id", "VendorId", "RequestId", "FaxNumber", "Email", "BusinessContact", "Prescription", "NoOfRefill", "CreatedDate", "CreatedBy") FROM stdin;
\.
COPY public."OrderDetails" ("Id", "VendorId", "RequestId", "FaxNumber", "Email", "BusinessContact", "Prescription", "NoOfRefill", "CreatedDate", "CreatedBy") FROM '$$PATH$$/5184.dat';

--
-- Data for Name: Physician; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Physician" ("PhysicianId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "MedicalLicense", "Photo", "AdminNotes", "IsAgreementDoc", "IsBackgroundDoc", "IsTrainingDoc", "IsNonDisclosureDoc", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "BusinessName", "BusinessWebsite", "IsDeleted", "RoleId", "NPINumber", "IsLicenseDoc", "Signature", "IsCredentialDoc", "IsTokenGenerate", "SyncEmailAddress") FROM stdin;
\.
COPY public."Physician" ("PhysicianId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "MedicalLicense", "Photo", "AdminNotes", "IsAgreementDoc", "IsBackgroundDoc", "IsTrainingDoc", "IsNonDisclosureDoc", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "BusinessName", "BusinessWebsite", "IsDeleted", "RoleId", "NPINumber", "IsLicenseDoc", "Signature", "IsCredentialDoc", "IsTokenGenerate", "SyncEmailAddress") FROM '$$PATH$$/5186.dat';

--
-- Data for Name: PhysicianLocation; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PhysicianLocation" ("LocationId", "PhysicianId", "Latitude", "Longitude", "CreatedDate", "PhysicianName", "Address") FROM stdin;
\.
COPY public."PhysicianLocation" ("LocationId", "PhysicianId", "Latitude", "Longitude", "CreatedDate", "PhysicianName", "Address") FROM '$$PATH$$/5187.dat';

--
-- Data for Name: PhysicianNotification; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PhysicianNotification" (id, "PhysicianId", "IsNotificationStopped") FROM stdin;
\.
COPY public."PhysicianNotification" (id, "PhysicianId", "IsNotificationStopped") FROM '$$PATH$$/5189.dat';

--
-- Data for Name: PhysicianRegion; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PhysicianRegion" ("PhysicianRegionId", "PhysicianId", "RegionId") FROM stdin;
\.
COPY public."PhysicianRegion" ("PhysicianRegionId", "PhysicianId", "RegionId") FROM '$$PATH$$/5191.dat';

--
-- Data for Name: Region; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Region" ("RegionId", "Name", "Abbreviation") FROM stdin;
\.
COPY public."Region" ("RegionId", "Name", "Abbreviation") FROM '$$PATH$$/5194.dat';

--
-- Data for Name: Request; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Request" ("RequestId", "RequestTypeId", "UserId", "FirstName", "LastName", "PhoneNumber", "Email", "Status", "PhysicianId", "ConfirmationNumber", "CreatedDate", "IsDeleted", "ModifiedDate", "DeclinedBy", "IsUrgentEmailSent", "LastWellnessDate", "IsMobile", "CallType", "CompletedByPhysician", "LastReservationDate", "AcceptedDate", "RelationName", "CaseNumber", "IP", "CaseTag", "CaseTagPhysician", "PatientAccountId", "CreatedUserId") FROM stdin;
\.
COPY public."Request" ("RequestId", "RequestTypeId", "UserId", "FirstName", "LastName", "PhoneNumber", "Email", "Status", "PhysicianId", "ConfirmationNumber", "CreatedDate", "IsDeleted", "ModifiedDate", "DeclinedBy", "IsUrgentEmailSent", "LastWellnessDate", "IsMobile", "CallType", "CompletedByPhysician", "LastReservationDate", "AcceptedDate", "RelationName", "CaseNumber", "IP", "CaseTag", "CaseTagPhysician", "PatientAccountId", "CreatedUserId") FROM '$$PATH$$/5196.dat';

--
-- Data for Name: RequestBusiness; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestBusiness" ("RequestBusinessId", "RequestId", "BusinessId", "IP") FROM stdin;
\.
COPY public."RequestBusiness" ("RequestBusinessId", "RequestId", "BusinessId", "IP") FROM '$$PATH$$/5197.dat';

--
-- Data for Name: RequestClient; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestClient" ("RequestClientId", "RequestId", "FirstName", "LastName", "PhoneNumber", "Location", "Address", "RegionId", "NotiMobile", "NotiEmail", "Notes", "Email", "strMonth", "intYear", "intDate", "IsMobile", "Street", "City", "State", "ZipCode", "CommunicationType", "RemindReservationCount", "RemindHouseCallCount", "IsSetFollowupSent", "IP", "IsReservationReminderSent", "Latitude", "Longitude") FROM stdin;
\.
COPY public."RequestClient" ("RequestClientId", "RequestId", "FirstName", "LastName", "PhoneNumber", "Location", "Address", "RegionId", "NotiMobile", "NotiEmail", "Notes", "Email", "strMonth", "intYear", "intDate", "IsMobile", "Street", "City", "State", "ZipCode", "CommunicationType", "RemindReservationCount", "RemindHouseCallCount", "IsSetFollowupSent", "IP", "IsReservationReminderSent", "Latitude", "Longitude") FROM '$$PATH$$/5199.dat';

--
-- Data for Name: RequestClosed; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestClosed" ("RequestClosedId", "RequestId", "RequestStatusLogId", "PhyNotes", "ClientNotes", "IP") FROM stdin;
\.
COPY public."RequestClosed" ("RequestClosedId", "RequestId", "RequestStatusLogId", "PhyNotes", "ClientNotes", "IP") FROM '$$PATH$$/5201.dat';

--
-- Data for Name: RequestConcierge; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestConcierge" ("Id", "RequestId", "ConciergeId", "IP") FROM stdin;
\.
COPY public."RequestConcierge" ("Id", "RequestId", "ConciergeId", "IP") FROM '$$PATH$$/5203.dat';

--
-- Data for Name: RequestNotes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestNotes" ("RequestNotesId", "RequestId", "strMonth", "intYear", "intDate", "PhysicianNotes", "AdminNotes", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IP", "AdministrativeNotes") FROM stdin;
\.
COPY public."RequestNotes" ("RequestNotesId", "RequestId", "strMonth", "intYear", "intDate", "PhysicianNotes", "AdminNotes", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IP", "AdministrativeNotes") FROM '$$PATH$$/5205.dat';

--
-- Data for Name: RequestStatusLog; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestStatusLog" ("RequestStatusLogId", "RequestId", "Status", "PhysicianId", "AdminId", "TransToPhysicianId", "Notes", "CreatedDate", "IP", "TransToAdmin") FROM stdin;
\.
COPY public."RequestStatusLog" ("RequestStatusLogId", "RequestId", "Status", "PhysicianId", "AdminId", "TransToPhysicianId", "Notes", "CreatedDate", "IP", "TransToAdmin") FROM '$$PATH$$/5207.dat';

--
-- Data for Name: RequestType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestType" ("RequestTypeId", "Name") FROM stdin;
\.
COPY public."RequestType" ("RequestTypeId", "Name") FROM '$$PATH$$/5209.dat';

--
-- Data for Name: RequestWiseFile; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RequestWiseFile" ("RequestWiseFileID", "RequestId", "FileName", "CreatedDate", "PhysicianId", "AdminId", "DocType", "IsFrontSide", "IsCompensation", "IP", "IsFinalize", "IsDeleted", "IsPatientRecords") FROM stdin;
\.
COPY public."RequestWiseFile" ("RequestWiseFileID", "RequestId", "FileName", "CreatedDate", "PhysicianId", "AdminId", "DocType", "IsFrontSide", "IsCompensation", "IP", "IsFinalize", "IsDeleted", "IsPatientRecords") FROM '$$PATH$$/5211.dat';

--
-- Data for Name: Role; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Role" ("RoleId", "Name", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IsDeleted", "IP", "AccountType") FROM stdin;
\.
COPY public."Role" ("RoleId", "Name", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IsDeleted", "IP", "AccountType") FROM '$$PATH$$/5214.dat';

--
-- Data for Name: RoleMenu; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RoleMenu" ("RoleMenuId", "RoleId", "MenuId") FROM stdin;
\.
COPY public."RoleMenu" ("RoleMenuId", "RoleId", "MenuId") FROM '$$PATH$$/5215.dat';

--
-- Data for Name: SMSLog; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."SMSLog" ("SMSLogID", "SMSTemplate", "MobileNumber", "ConfirmationNumber", "RoleId", "AdminId", "RequestId", "PhysicianId", "CreateDate", "SentDate", "IsSMSSent", "SentTries", "Action") FROM stdin;
\.
COPY public."SMSLog" ("SMSLogID", "SMSTemplate", "MobileNumber", "ConfirmationNumber", "RoleId", "AdminId", "RequestId", "PhysicianId", "CreateDate", "SentDate", "IsSMSSent", "SentTries", "Action") FROM '$$PATH$$/5218.dat';

--
-- Data for Name: Shift; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Shift" ("ShiftId", "PhysicianId", "StartDate", "IsRepeat", "WeekDays", "RepeatUpto", "CreatedBy", "CreatedDate", "IP") FROM stdin;
\.
COPY public."Shift" ("ShiftId", "PhysicianId", "StartDate", "IsRepeat", "WeekDays", "RepeatUpto", "CreatedBy", "CreatedDate", "IP") FROM '$$PATH$$/5220.dat';

--
-- Data for Name: ShiftDetail; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ShiftDetail" ("ShiftDetailId", "ShiftId", "ShiftDate", "RegionId", "StartTime", "EndTime", "Status", "IsDeleted", "ModifiedBy", "ModifiedDate", "LastRunningDate", "EventId", "IsSync") FROM stdin;
\.
COPY public."ShiftDetail" ("ShiftDetailId", "ShiftId", "ShiftDate", "RegionId", "StartTime", "EndTime", "Status", "IsDeleted", "ModifiedBy", "ModifiedDate", "LastRunningDate", "EventId", "IsSync") FROM '$$PATH$$/5221.dat';

--
-- Data for Name: ShiftDetailRegion; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ShiftDetailRegion" ("ShiftDetailRegionId", "ShiftDetailId", "RegionId", "IsDeleted") FROM stdin;
\.
COPY public."ShiftDetailRegion" ("ShiftDetailRegionId", "ShiftDetailId", "RegionId", "IsDeleted") FROM '$$PATH$$/5222.dat';

--
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."User" ("UserId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "IsMobile", "Street", "City", "State", "RegionId", "ZipCode", "strMonth", "intYear", "intDate", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP", "IsRequestWithEmail") FROM stdin;
\.
COPY public."User" ("UserId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "IsMobile", "Street", "City", "State", "RegionId", "ZipCode", "strMonth", "intYear", "intDate", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP", "IsRequestWithEmail") FROM '$$PATH$$/5226.dat';

--
-- Name: AdminRegion_AdminRegionId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AdminRegion_AdminRegionId_seq"', 20, true);


--
-- Name: Admin_AdminId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Admin_AdminId_seq"', 4, true);


--
-- Name: BlockRequests_BlockRequestId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."BlockRequests_BlockRequestId_seq"', 10, true);


--
-- Name: Business_BusinessId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Business_BusinessId_seq"', 14, true);


--
-- Name: CaseTag_CaseTagId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."CaseTag_CaseTagId_seq"', 7, true);


--
-- Name: Concierge_ConciergeId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Concierge_ConciergeId_seq"', 13, true);


--
-- Name: EmailLog_EmailLogID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."EmailLog_EmailLogID_seq"', 5, true);


--
-- Name: EncounterForm_EncounterFormId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."EncounterForm_EncounterFormId_seq"', 6, true);


--
-- Name: HealthProfessionalType_HealthProfessionalId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."HealthProfessionalType_HealthProfessionalId_seq"', 3, true);


--
-- Name: HealthProfessionals_VendorId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."HealthProfessionals_VendorId_seq"', 10, true);


--
-- Name: Menu_MenuId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Menu_MenuId_seq"', 29, true);


--
-- Name: OrderDetails_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."OrderDetails_Id_seq"', 2, true);


--
-- Name: PhysicianLocation_LocationId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PhysicianLocation_LocationId_seq"', 3, true);


--
-- Name: PhysicianNotification_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PhysicianNotification_id_seq"', 23, true);


--
-- Name: PhysicianRegion_PhysicianRegionId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PhysicianRegion_PhysicianRegionId_seq"', 27, true);


--
-- Name: Physician_PhysicianId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Physician_PhysicianId_seq"', 11, true);


--
-- Name: Region_RegionId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Region_RegionId_seq"', 1, true);


--
-- Name: RequestBusiness_RequestBusinessId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestBusiness_RequestBusinessId_seq"', 1, false);


--
-- Name: RequestClient_RequestClientId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestClient_RequestClientId_seq"', 61, true);


--
-- Name: RequestClosed_RequestClosedId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestClosed_RequestClosedId_seq"', 1, false);


--
-- Name: RequestConcierge_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestConcierge_Id_seq"', 1, false);


--
-- Name: RequestNotes_RequestNotesId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestNotes_RequestNotesId_seq"', 5, true);


--
-- Name: RequestStatusLog_RequestStatusLogId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestStatusLog_RequestStatusLogId_seq"', 76, true);


--
-- Name: RequestType_RequestTypeId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestType_RequestTypeId_seq"', 1, false);


--
-- Name: RequestWiseFile_RequestWiseFileID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RequestWiseFile_RequestWiseFileID_seq"', 72, true);


--
-- Name: Request_RequestId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Request_RequestId_seq"', 68, true);


--
-- Name: RoleMenu_RoleMenuId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RoleMenu_RoleMenuId_seq"', 30, true);


--
-- Name: Role_RoleId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Role_RoleId_seq"', 41, true);


--
-- Name: SMSLog_SMSLogID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."SMSLog_SMSLogID_seq"', 1, false);


--
-- Name: ShiftDetailRegion_ShiftDetailRegionId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ShiftDetailRegion_ShiftDetailRegionId_seq"', 1, false);


--
-- Name: ShiftDetail_ShiftDetailId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ShiftDetail_ShiftDetailId_seq"', 38, true);


--
-- Name: Shift_ShiftId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Shift_ShiftId_seq"', 26, true);


--
-- Name: User_UserId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."User_UserId_seq"', 4, true);


--
-- Name: AdminRegion AdminRegion_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "AdminRegion_pkey" PRIMARY KEY ("AdminRegionId");


--
-- Name: Admin Admin_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_pkey" PRIMARY KEY ("AdminId");


--
-- Name: AspNetRoles AspNetRoles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "AspNetRoles_pkey" PRIMARY KEY ("Id");


--
-- Name: AspNetUserRoles AspNetUserRoles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "AspNetUserRoles_pkey" PRIMARY KEY ("UserId", "RoleId");


--
-- Name: AspNetUsers AspNetUsers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "AspNetUsers_pkey" PRIMARY KEY ("Id");


--
-- Name: BlockRequests BlockRequests_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BlockRequests"
    ADD CONSTRAINT "BlockRequests_pkey" PRIMARY KEY ("BlockRequestId");


--
-- Name: Business Business_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_pkey" PRIMARY KEY ("BusinessId");


--
-- Name: Concierge Concierge_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Concierge"
    ADD CONSTRAINT "Concierge_pkey" PRIMARY KEY ("ConciergeId");


--
-- Name: EmailLog EmailLog_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EmailLog"
    ADD CONSTRAINT "EmailLog_pkey" PRIMARY KEY ("EmailLogID");


--
-- Name: EncounterForm EncounterForm_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_pkey" PRIMARY KEY ("EncounterFormId");


--
-- Name: HealthProfessionalType HealthProfessionalType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HealthProfessionalType"
    ADD CONSTRAINT "HealthProfessionalType_pkey" PRIMARY KEY ("HealthProfessionalId");


--
-- Name: HealthProfessionals HealthProfessionals_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HealthProfessionals"
    ADD CONSTRAINT "HealthProfessionals_pkey" PRIMARY KEY ("VendorId");


--
-- Name: Menu Menu_AccountType_check; Type: CHECK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE public."Menu"
    ADD CONSTRAINT "Menu_AccountType_check" CHECK (("AccountType" = ANY (ARRAY[1, 2, 3, 4]))) NOT VALID;


--
-- Name: Menu Menu_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Menu"
    ADD CONSTRAINT "Menu_pkey" PRIMARY KEY ("MenuId");


--
-- Name: OrderDetails OrderDetails_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderDetails"
    ADD CONSTRAINT "OrderDetails_pkey" PRIMARY KEY ("Id");


--
-- Name: PhysicianNotification PhysicianNotification_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianNotification"
    ADD CONSTRAINT "PhysicianNotification_pkey" PRIMARY KEY (id);


--
-- Name: PhysicianRegion PhysicianRegion_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_pkey" PRIMARY KEY ("PhysicianRegionId");


--
-- Name: Physician Physician_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_pkey" PRIMARY KEY ("PhysicianId");


--
-- Name: Region Region_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Region"
    ADD CONSTRAINT "Region_pkey" PRIMARY KEY ("RegionId");


--
-- Name: RequestBusiness RequestBusiness_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_pkey" PRIMARY KEY ("RequestBusinessId");


--
-- Name: RequestClient RequestClient_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_pkey" PRIMARY KEY ("RequestClientId");


--
-- Name: RequestClosed RequestClosed_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_pkey" PRIMARY KEY ("RequestClosedId");


--
-- Name: RequestConcierge RequestConcierge_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_pkey" PRIMARY KEY ("Id");


--
-- Name: RequestNotes RequestNotes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestNotes"
    ADD CONSTRAINT "RequestNotes_pkey" PRIMARY KEY ("RequestNotesId");


--
-- Name: RequestStatusLog RequestStatusLog_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_pkey" PRIMARY KEY ("RequestStatusLogId");


--
-- Name: RequestType RequestType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestType"
    ADD CONSTRAINT "RequestType_pkey" PRIMARY KEY ("RequestTypeId");


--
-- Name: RequestWiseFile RequestWiseFile_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_pkey" PRIMARY KEY ("RequestWiseFileID");


--
-- Name: Request Request_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_pkey" PRIMARY KEY ("RequestId");


--
-- Name: RoleMenu RoleMenu_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_pkey" PRIMARY KEY ("RoleMenuId");


--
-- Name: Role Role_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("RoleId");


--
-- Name: SMSLog SMSLog_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SMSLog"
    ADD CONSTRAINT "SMSLog_pkey" PRIMARY KEY ("SMSLogID");


--
-- Name: ShiftDetailRegion ShiftDetailRegion_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_pkey" PRIMARY KEY ("ShiftDetailRegionId");


--
-- Name: ShiftDetail ShiftDetail_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_pkey" PRIMARY KEY ("ShiftDetailId");


--
-- Name: Shift Shift_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_pkey" PRIMARY KEY ("ShiftId");


--
-- Name: User User_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("UserId");


--
-- Name: Admin Admin_AspNetUserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Admin Admin_ModifiedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Business Business_CreatedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Business Business_ModifiedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Business Business_RegionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: Concierge Concierge_RegionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Concierge"
    ADD CONSTRAINT "Concierge_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: EncounterForm EncounterForm_AdminId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_AdminId_fkey" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");


--
-- Name: EncounterForm EncounterForm_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: EncounterForm EncounterForm_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: AdminRegion FK_AdminRegion_AdminId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "FK_AdminRegion_AdminId" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");


--
-- Name: AdminRegion FK_AdminRegion_RegionId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "FK_AdminRegion_RegionId" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: HealthProfessionals HealthProfessionals_Profession_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HealthProfessionals"
    ADD CONSTRAINT "HealthProfessionals_Profession_fkey" FOREIGN KEY ("Profession") REFERENCES public."HealthProfessionalType"("HealthProfessionalId");


--
-- Name: PhysicianLocation PhysicianLocation_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianLocation"
    ADD CONSTRAINT "PhysicianLocation_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: PhysicianNotification PhysicianNotification_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianNotification"
    ADD CONSTRAINT "PhysicianNotification_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: PhysicianRegion PhysicianRegion_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: PhysicianRegion PhysicianRegion_RegionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: Physician Physician_AspNetUserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Physician Physician_CreatedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Physician Physician_ModifiedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Physician Physician_RoleId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Role"("RoleId");


--
-- Name: RequestBusiness RequestBusiness_BusinessId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_BusinessId_fkey" FOREIGN KEY ("BusinessId") REFERENCES public."Business"("BusinessId");


--
-- Name: RequestBusiness RequestBusiness_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestClient RequestClient_RegionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: RequestClient RequestClient_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestClosed RequestClosed_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestClosed RequestClosed_RequestStatusLogId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_RequestStatusLogId_fkey" FOREIGN KEY ("RequestStatusLogId") REFERENCES public."RequestStatusLog"("RequestStatusLogId");


--
-- Name: RequestConcierge RequestConcierge_ConciergeId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_ConciergeId_fkey" FOREIGN KEY ("ConciergeId") REFERENCES public."Concierge"("ConciergeId");


--
-- Name: RequestConcierge RequestConcierge_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestNotes RequestNotes_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestNotes"
    ADD CONSTRAINT "RequestNotes_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestStatusLog RequestStatusLog_AdminId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_AdminId_fkey" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");


--
-- Name: RequestStatusLog RequestStatusLog_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: RequestStatusLog RequestStatusLog_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: RequestStatusLog RequestStatusLog_TransToPhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_TransToPhysicianId_fkey" FOREIGN KEY ("TransToPhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: RequestWiseFile RequestWiseFile_AdminId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_AdminId_fkey" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");


--
-- Name: RequestWiseFile RequestWiseFile_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: RequestWiseFile RequestWiseFile_RequestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");


--
-- Name: Request Request_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: Request Request_UserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."User"("UserId");


--
-- Name: RoleMenu RoleMenu_MenuId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_MenuId_fkey" FOREIGN KEY ("MenuId") REFERENCES public."Menu"("MenuId");


--
-- Name: RoleMenu RoleMenu_RoleId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Role"("RoleId");


--
-- Name: ShiftDetailRegion ShiftDetailRegion_RegionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");


--
-- Name: ShiftDetailRegion ShiftDetailRegion_ShiftDetailId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_ShiftDetailId_fkey" FOREIGN KEY ("ShiftDetailId") REFERENCES public."ShiftDetail"("ShiftDetailId");


--
-- Name: ShiftDetail ShiftDetail_ModifiedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: ShiftDetail ShiftDetail_RegionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId") NOT VALID;


--
-- Name: ShiftDetail ShiftDetail_ShiftId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_ShiftId_fkey" FOREIGN KEY ("ShiftId") REFERENCES public."Shift"("ShiftId");


--
-- Name: Shift Shift_CreatedBy_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");


--
-- Name: Shift Shift_PhysicianId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");


--
-- Name: User User_AspNetUserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");


--
-- Name: AspNetUserRoles fk_aspnetuserrole_aspnetuser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT fk_aspnetuserrole_aspnetuser FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id");


--
-- Name: AspNetUserRoles fk_aspnetuserrole_role; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT fk_aspnetuserrole_role FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id");


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        