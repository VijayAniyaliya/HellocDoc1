toc.dat                                                                                             0000600 0004000 0002000 00000010250 14612202536 0014436 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP       +                |            Assignments    16.1    16.1     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false         �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false         �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false         �           1262    99403    Assignments    DATABASE     �   CREATE DATABASE "Assignments" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';
    DROP DATABASE "Assignments";
                postgres    false         �            1259    99404    Doctor    TABLE     q   CREATE TABLE public."Doctor" (
    "DoctorId" integer NOT NULL,
    ". Specialist" character varying NOT NULL
);
    DROP TABLE public."Doctor";
       public         heap    postgres    false         �            1259    99407    Doctor_DoctorId_seq    SEQUENCE     �   ALTER TABLE public."Doctor" ALTER COLUMN "DoctorId" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Doctor_DoctorId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215         �            1259    99413    Patient    TABLE     �  CREATE TABLE public."Patient" (
    "Id" integer NOT NULL,
    " FirstName" character varying NOT NULL,
    "LastName" character varying NOT NULL,
    "DoctortId " integer NOT NULL,
    "Age" smallint NOT NULL,
    "Email" character varying NOT NULL,
    "PhoneNo" character varying NOT NULL,
    "Gender" integer NOT NULL,
    "Disease" integer NOT NULL,
    "Specialist" character varying NOT NULL
);
    DROP TABLE public."Patient";
       public         heap    postgres    false         �            1259    99416    Patient_Id_seq    SEQUENCE     �   ALTER TABLE public."Patient" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Patient_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    217         �          0    99404    Doctor 
   TABLE DATA           >   COPY public."Doctor" ("DoctorId", ". Specialist") FROM stdin;
    public          postgres    false    215       4842.dat �          0    99413    Patient 
   TABLE DATA           �   COPY public."Patient" ("Id", " FirstName", "LastName", "DoctortId ", "Age", "Email", "PhoneNo", "Gender", "Disease", "Specialist") FROM stdin;
    public          postgres    false    217       4844.dat �           0    0    Doctor_DoctorId_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public."Doctor_DoctorId_seq"', 10, true);
          public          postgres    false    216         �           0    0    Patient_Id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Patient_Id_seq"', 12, true);
          public          postgres    false    218         W           2606    99412    Doctor Doctor_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."Doctor"
    ADD CONSTRAINT "Doctor_pkey" PRIMARY KEY ("DoctorId");
 @   ALTER TABLE ONLY public."Doctor" DROP CONSTRAINT "Doctor_pkey";
       public            postgres    false    215         Y           2606    99421    Patient Patient_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Patient"
    ADD CONSTRAINT "Patient_pkey" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Patient" DROP CONSTRAINT "Patient_pkey";
       public            postgres    false    217         Z           2606    99422    Patient DoctortId     FK CONSTRAINT     �   ALTER TABLE ONLY public."Patient"
    ADD CONSTRAINT "DoctortId " FOREIGN KEY ("DoctortId ") REFERENCES public."Doctor"("DoctorId") NOT VALID;
 @   ALTER TABLE ONLY public."Patient" DROP CONSTRAINT "DoctortId ";
       public          postgres    false    4695    215    217                                                                                                                                                                                                                                                                                                                                                                4842.dat                                                                                            0000600 0004000 0002000 00000000137 14612202536 0014255 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	Gynacology
2	Brain-Disease
3	Fever/Flu
4	Dental
5	Heart Disease
6	Joint Pain
10	Surgery
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                 4844.dat                                                                                            0000600 0004000 0002000 00000001015 14612202536 0014253 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        7	parth	admintest	3	21	sandip123@gmail.com	9313592438	1	2	Fever/Flu
3	tatvasoft	admintest	10	21	x@gmail.com	9313592437	1	3	Surgery
9	parth	raj	10	21	ps123@gmail.com	9313592438	1	3	Surgery
6	tirth	patels	10	20	ps@gmail.com	9313592437	1	3	Surgery
8	tatvasoftnewtest	dabhi	5	21	demo123@gmail.com	9313592434	1	2	Heart Disease
10	test	admintest	10	22	vindit23273@gmail.com	9313592437	1	3	Surgery
11	sandip	admin	1	22	vinit22733@gmail.com	9313592438	1	5	Gynacology
12	tirth	dabhi	1	23	x123@gmail.com	9313592437	1	3	Gynacology
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   restore.sql                                                                                         0000600 0004000 0002000 00000010200 14612202536 0015356 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
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

DROP DATABASE "Assignments";
--
-- Name: Assignments; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "Assignments" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';


ALTER DATABASE "Assignments" OWNER TO postgres;

\connect "Assignments"

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
-- Name: Doctor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Doctor" (
    "DoctorId" integer NOT NULL,
    ". Specialist" character varying NOT NULL
);


ALTER TABLE public."Doctor" OWNER TO postgres;

--
-- Name: Doctor_DoctorId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Doctor" ALTER COLUMN "DoctorId" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Doctor_DoctorId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Patient; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Patient" (
    "Id" integer NOT NULL,
    " FirstName" character varying NOT NULL,
    "LastName" character varying NOT NULL,
    "DoctortId " integer NOT NULL,
    "Age" smallint NOT NULL,
    "Email" character varying NOT NULL,
    "PhoneNo" character varying NOT NULL,
    "Gender" integer NOT NULL,
    "Disease" integer NOT NULL,
    "Specialist" character varying NOT NULL
);


ALTER TABLE public."Patient" OWNER TO postgres;

--
-- Name: Patient_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Patient" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Patient_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Data for Name: Doctor; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Doctor" ("DoctorId", ". Specialist") FROM stdin;
\.
COPY public."Doctor" ("DoctorId", ". Specialist") FROM '$$PATH$$/4842.dat';

--
-- Data for Name: Patient; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Patient" ("Id", " FirstName", "LastName", "DoctortId ", "Age", "Email", "PhoneNo", "Gender", "Disease", "Specialist") FROM stdin;
\.
COPY public."Patient" ("Id", " FirstName", "LastName", "DoctortId ", "Age", "Email", "PhoneNo", "Gender", "Disease", "Specialist") FROM '$$PATH$$/4844.dat';

--
-- Name: Doctor_DoctorId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Doctor_DoctorId_seq"', 10, true);


--
-- Name: Patient_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Patient_Id_seq"', 12, true);


--
-- Name: Doctor Doctor_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Doctor"
    ADD CONSTRAINT "Doctor_pkey" PRIMARY KEY ("DoctorId");


--
-- Name: Patient Patient_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Patient"
    ADD CONSTRAINT "Patient_pkey" PRIMARY KEY ("Id");


--
-- Name: Patient DoctortId ; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Patient"
    ADD CONSTRAINT "DoctortId " FOREIGN KEY ("DoctortId ") REFERENCES public."Doctor"("DoctorId") NOT VALID;


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                