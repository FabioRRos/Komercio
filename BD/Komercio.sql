--
-- PostgreSQL database dump
--

-- Dumped from database version 16.9
-- Dumped by pg_dump version 16.9

-- Started on 2025-11-03 20:41:51

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
-- TOC entry 230 (class 1259 OID 32842)
-- Name: cash_movements; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cash_movements (
    movement_id integer NOT NULL,
    sale_id integer,
    movement_type character varying(50) NOT NULL,
    description text,
    amount numeric(10,2) NOT NULL,
    payment_method character varying(50) NOT NULL,
    movement_datetime timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    seller_id integer NOT NULL,
    CONSTRAINT cash_movements_amount_check CHECK ((amount >= (0)::numeric))
);


ALTER TABLE public.cash_movements OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 32841)
-- Name: cash_movements_movement_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.cash_movements_movement_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.cash_movements_movement_id_seq OWNER TO postgres;

--
-- TOC entry 4973 (class 0 OID 0)
-- Dependencies: 229
-- Name: cash_movements_movement_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.cash_movements_movement_id_seq OWNED BY public.cash_movements.movement_id;


--
-- TOC entry 218 (class 1259 OID 24577)
-- Name: customers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.customers (
    customerid integer NOT NULL,
    customerfirstname character varying(100) NOT NULL,
    customerlastname character varying(100) NOT NULL,
    customerdocument character varying(20) NOT NULL,
    customerphone character varying(20),
    customermobile character varying(20),
    customeraddressline character varying(200),
    customerzipcode character varying(20),
    customerneighborhood character varying(100),
    customercity character varying(100),
    customerstate character varying(50),
    customercountry character varying(50) DEFAULT 'Brazil'::character varying,
    customeremail character varying(100),
    customeraccountid integer,
    customerstatus boolean DEFAULT true
);


ALTER TABLE public.customers OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 24576)
-- Name: customers_customerid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.customers_customerid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.customers_customerid_seq OWNER TO postgres;

--
-- TOC entry 4974 (class 0 OID 0)
-- Dependencies: 217
-- Name: customers_customerid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.customers_customerid_seq OWNED BY public.customers.customerid;


--
-- TOC entry 220 (class 1259 OID 32769)
-- Name: employees; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employees (
    employeeid integer NOT NULL,
    employeefullname character varying(100) NOT NULL,
    employeelogin character varying(50) NOT NULL,
    employeepassword character varying(255) NOT NULL,
    employeestatus boolean DEFAULT true
);


ALTER TABLE public.employees OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 32768)
-- Name: employees_employeeid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.employees_employeeid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.employees_employeeid_seq OWNER TO postgres;

--
-- TOC entry 4975 (class 0 OID 0)
-- Dependencies: 219
-- Name: employees_employeeid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.employees_employeeid_seq OWNED BY public.employees.employeeid;


--
-- TOC entry 226 (class 1259 OID 32827)
-- Name: product_group; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product_group (
    group_id integer NOT NULL,
    group_name character varying(100) NOT NULL
);


ALTER TABLE public.product_group OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 32826)
-- Name: product_group_group_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.product_group_group_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.product_group_group_id_seq OWNER TO postgres;

--
-- TOC entry 4976 (class 0 OID 0)
-- Dependencies: 225
-- Name: product_group_group_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.product_group_group_id_seq OWNED BY public.product_group.group_id;


--
-- TOC entry 224 (class 1259 OID 32820)
-- Name: product_subgroup; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product_subgroup (
    subgroup_id integer NOT NULL,
    subgroup_name character varying(100) NOT NULL
);


ALTER TABLE public.product_subgroup OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 32819)
-- Name: product_subgroup_subgroup_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.product_subgroup_subgroup_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.product_subgroup_subgroup_id_seq OWNER TO postgres;

--
-- TOC entry 4977 (class 0 OID 0)
-- Dependencies: 223
-- Name: product_subgroup_subgroup_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.product_subgroup_subgroup_id_seq OWNED BY public.product_subgroup.subgroup_id;


--
-- TOC entry 216 (class 1259 OID 16409)
-- Name: products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.products (
    id integer NOT NULL,
    productname character varying(255) NOT NULL,
    productprice real NOT NULL,
    productcodbar character varying(50),
    productgroup character varying(100),
    productsubgroup character varying(100),
    productstock integer DEFAULT 0,
    status boolean DEFAULT true
);


ALTER TABLE public.products OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16408)
-- Name: products_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.products_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.products_id_seq OWNER TO postgres;

--
-- TOC entry 4978 (class 0 OID 0)
-- Dependencies: 215
-- Name: products_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.products_id_seq OWNED BY public.products.id;


--
-- TOC entry 228 (class 1259 OID 32834)
-- Name: sale_items; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sale_items (
    sale_item_id integer NOT NULL,
    sale_id integer NOT NULL,
    product_id integer NOT NULL,
    product_name character varying(150) NOT NULL,
    barcode character varying(50),
    unit_price numeric(10,2) NOT NULL,
    quantity integer NOT NULL,
    total numeric(10,2),
    CONSTRAINT sale_items_quantity_check CHECK ((quantity > 0))
);


ALTER TABLE public.sale_items OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 32833)
-- Name: sale_items_sale_item_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sale_items_sale_item_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sale_items_sale_item_id_seq OWNER TO postgres;

--
-- TOC entry 4979 (class 0 OID 0)
-- Dependencies: 227
-- Name: sale_items_sale_item_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sale_items_sale_item_id_seq OWNED BY public.sale_items.sale_item_id;


--
-- TOC entry 222 (class 1259 OID 32808)
-- Name: sales; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sales (
    sale_id integer NOT NULL,
    customer_id integer NOT NULL,
    total_amount numeric(10,2) NOT NULL,
    discount_amount numeric(10,2) DEFAULT 0,
    final_amount numeric(10,2) NOT NULL,
    sale_date date DEFAULT CURRENT_DATE NOT NULL,
    sale_time time without time zone DEFAULT CURRENT_TIME NOT NULL,
    payment_method character varying(50) NOT NULL,
    seller_id integer NOT NULL,
    sale_notes text
);


ALTER TABLE public.sales OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 32807)
-- Name: sales_sale_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sales_sale_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sales_sale_id_seq OWNER TO postgres;

--
-- TOC entry 4980 (class 0 OID 0)
-- Dependencies: 221
-- Name: sales_sale_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sales_sale_id_seq OWNED BY public.sales.sale_id;


--
-- TOC entry 4785 (class 2604 OID 32845)
-- Name: cash_movements movement_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cash_movements ALTER COLUMN movement_id SET DEFAULT nextval('public.cash_movements_movement_id_seq'::regclass);


--
-- TOC entry 4773 (class 2604 OID 24580)
-- Name: customers customerid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.customers ALTER COLUMN customerid SET DEFAULT nextval('public.customers_customerid_seq'::regclass);


--
-- TOC entry 4776 (class 2604 OID 32772)
-- Name: employees employeeid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees ALTER COLUMN employeeid SET DEFAULT nextval('public.employees_employeeid_seq'::regclass);


--
-- TOC entry 4783 (class 2604 OID 32830)
-- Name: product_group group_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_group ALTER COLUMN group_id SET DEFAULT nextval('public.product_group_group_id_seq'::regclass);


--
-- TOC entry 4782 (class 2604 OID 32823)
-- Name: product_subgroup subgroup_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_subgroup ALTER COLUMN subgroup_id SET DEFAULT nextval('public.product_subgroup_subgroup_id_seq'::regclass);


--
-- TOC entry 4770 (class 2604 OID 16412)
-- Name: products id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products ALTER COLUMN id SET DEFAULT nextval('public.products_id_seq'::regclass);


--
-- TOC entry 4784 (class 2604 OID 32837)
-- Name: sale_items sale_item_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sale_items ALTER COLUMN sale_item_id SET DEFAULT nextval('public.sale_items_sale_item_id_seq'::regclass);


--
-- TOC entry 4778 (class 2604 OID 32811)
-- Name: sales sale_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sales ALTER COLUMN sale_id SET DEFAULT nextval('public.sales_sale_id_seq'::regclass);


--
-- TOC entry 4967 (class 0 OID 32842)
-- Dependencies: 230
-- Data for Name: cash_movements; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.cash_movements (movement_id, sale_id, movement_type, description, amount, payment_method, movement_datetime, seller_id) FROM stdin;
1	1	Entrada		19.90	Dinheiro	2025-10-29 18:48:49.102833	3
2	2	Entrada		19.90	Dinheiro	2025-10-29 19:46:21.744967	3
3	3	Entrada		1437.90	Dinheiro	2025-10-29 20:01:48.94732	3
4	4	Entrada		1352.00	Dinheiro	2025-10-29 20:43:13.331649	2
5	5	Entrada		9.90	Dinheiro	2025-10-29 21:38:26.345468	2
6	6	Entrada		19.90	Débito	2025-10-29 22:14:57.849326	2
7	7	Entrada		39.90	Dinheiro	2025-10-30 09:35:17.972608	3
8	8	Entrada		19.90	Dinheiro	2025-10-30 09:45:22.706453	1
9	9	Entrada		39.90	Conta	2025-10-30 09:47:11.092667	2
10	11	Entrada		509.30	Dinheiro	2025-11-02 14:23:36.849572	2
11	12	Entrada		509.30	Dinheiro	2025-11-02 17:16:13.619372	2
12	13	Entrada		29.90	Dinheiro	2025-11-02 17:27:16.70397	3
13	14	Entrada		24.90	Dinheiro	2025-11-02 17:28:39.947689	3
14	15	Entrada		24.90	Dinheiro	2025-11-02 17:29:31.381754	2
15	16	Entrada		29.90	Dinheiro	2025-11-02 17:31:34.738306	3
16	17	Entrada		24.90	Dinheiro	2025-11-02 17:32:51.378767	3
17	18	Entrada		1085.70	Dinheiro	2025-11-02 17:36:24.688023	3
18	19	Entrada		1437.60	Dinheiro	2025-11-02 17:41:34.000041	2
19	20	Entrada		29.90	Dinheiro	2025-11-02 17:42:28.979102	2
20	21	Entrada		39.90	Dinheiro	2025-11-02 17:43:35.044591	2
21	22	Entrada		89.90	Dinheiro	2025-11-02 17:44:10.835019	1
22	23	Entrada		39.90	Dinheiro	2025-11-02 17:45:02.350867	2
23	24	Entrada		24.90	Dinheiro	2025-11-02 17:47:12.10181	2
24	25	Entrada		19.90	Dinheiro	2025-11-02 17:49:08.106156	1
25	26	Entrada		1466.90	Dinheiro	2025-11-02 17:53:16.400379	2
26	27	Entrada		1084.70	Dinheiro	2025-11-02 18:01:10.256908	3
\.


--
-- TOC entry 4955 (class 0 OID 24577)
-- Dependencies: 218
-- Data for Name: customers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.customers (customerid, customerfirstname, customerlastname, customerdocument, customerphone, customermobile, customeraddressline, customerzipcode, customerneighborhood, customercity, customerstate, customercountry, customeremail, customeraccountid, customerstatus) FROM stdin;
1	Cliente	Balcão	11111111111										0	t
2	Fabio	Ricardo Ros	41915422817	1435721633	14997724891	Rua Licinio José da Silva 50	16600264	Vila Ortiz	Pirajuí	SP	Brasil	fabiorros@gmail.com.br	0	t
\.


--
-- TOC entry 4957 (class 0 OID 32769)
-- Dependencies: 220
-- Data for Name: employees; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employees (employeeid, employeefullname, employeelogin, employeepassword, employeestatus) FROM stdin;
1	Fabio Ricardo Ros	f.ros	P@ssw0rd	t
2	Aline Fernanda Ulian	a.ulian	vKEP82Xu	t
3	Maria Susana Candida de Jesus	m.jesus	P@ssw0rd	t
\.


--
-- TOC entry 4963 (class 0 OID 32827)
-- Dependencies: 226
-- Data for Name: product_group; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.product_group (group_id, group_name) FROM stdin;
1	Pelicula Vidro
2	Pelicula Gel
3	Pelicula Cerâmica
4	Capa Silicone
5	Capa Acrílico
6	Capa Couro
7	Acessórios de Som
8	Acessórios de Celular
9	TV Box e Streaming
10	Brinquedos
\.


--
-- TOC entry 4961 (class 0 OID 32820)
-- Dependencies: 224
-- Data for Name: product_subgroup; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.product_subgroup (subgroup_id, subgroup_name) FROM stdin;
1	Brilhante
2	Fosca
3	Brilhante de Privacidade
4	Fosca de Privacidade
5	Transparente
6	Preta
7	Vermelha
8	Azul
9	Anti Impacto + Transparente
10	Anti Impacto + Preta
11	Transparente
12	Fumê
13	Colorida
14	Couro Preto
15	Couro Marrom
16	Carteira + Preto
17	Carteira + Vermelho
18	Caixas Bluetooth
19	Fones de Ouvido
20	Microfones
21	Cabos P2
22	Carregadores
23	Cabo USB
24	Suporte Veicular
25	Power Bank
26	Anel de Suporte
27	TV Box
28	Chromecast
29	Cabo HDMI
30	Carrinhos
31	Bonecos
32	Slime
33	Pipas
\.


--
-- TOC entry 4953 (class 0 OID 16409)
-- Dependencies: 216
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.products (id, productname, productprice, productcodbar, productgroup, productsubgroup, productstock, status) FROM stdin;
3	Pelicula Gel Brilhante Motorola G60	15.9	789000003	Pelicula Gel	Brilhante	30	t
5	Pelicula Cerâmica Brilhante de Privacidade iPhone 13	25.9	789000005	Pelicula Cerâmica	Brilhante de Privacidade	25	t
6	Pelicula Cerâmica Fosca de Privacidade Samsung S22	27.9	789000006	Pelicula Cerâmica	Fosca de Privacidade	20	t
7	Capa Silicone Transparente iPhone 11	24.9	789000007	Capa Silicone	Transparente	60	t
8	Capa Silicone Preta Samsung A23	24.9	789000008	Capa Silicone	Preta	45	t
11	Capa Silicone Anti Impacto + Transparente Samsung A32	29.9	789000011	Capa Silicone	Anti Impacto + Transparente	40	t
14	Capa Acrílico Colorida Motorola Edge 30	34.9	789000014	Capa Acrílico	Colorida	20	t
21	Fone P2 com Microfone Genérico	24.9	789000021	Acessórios de Som	Fones de Ouvido	50	t
22	Microfone de Mesa USB Condensador	99.9	789000022	Acessórios de Som	Microfones	10	t
23	Microfone Lapela P2	29.9	789000023	Acessórios de Som	Microfones	25	t
35	Carrinho Fricção Pequeno	14.9	789000035	Brinquedos	Carrinhos	50	t
37	Slime Neon Pote 250g	12.9	789000037	Brinquedos	Slime	45	t
38	Pipa Pequena com Linha	9.9	789000038	Brinquedos	Pipas	60	t
40	Carrinho Controle Remoto Infantil	89.9	789000040	Brinquedos	Carrinhos	10	t
42	Slime Glitter Azul	13.9	789000042	Brinquedos	Slime	40	t
24	Cabo P2 Macho-Macho 1,5m	19.9	789000024	Acessórios de Som	Cabos P2	59	t
15	Capa Couro Preto iPhone 13	49.9	789000015	Capa Couro	Couro Preto	17	t
44	Carrinho Hot Wheels Genérico	11.9	789000044	Brinquedos	Carrinhos	79	t
29	Power Bank 10.000mAh	119.9	789000029	Acessórios de Celular	Power Bank	9	t
17	Capa Couro Carteira + Vermelho iPhone 11	54.9	789000017	Capa Couro	Carteira + Vermelho	1	t
20	Fone de Ouvido Bluetooth JBL Style	59.9	789000020	Acessórios de Som	Fones de Ouvido	20	t
12	Capa Acrílico Transparente iPhone 14	32.9	789000012	Capa Acrílico	Transparente	30	t
32	TV Box MXQ Pro 5G	229.9	789000032	TV Box e Streaming	TV Box	0	t
10	Capa Silicone Anti Impacto + Preta iPhone 13	29.9	789000010	Capa Silicone	Anti Impacto + Preta	16	t
26	Cabo USB-C Reforçado 1m	29.9	789000026	Acessórios de Celular	Cabo USB	79	t
13	Capa Acrílico Fumê Samsung A54	32.9	789000013	Capa Acrílico	Fumê	24	t
25	Carregador Turbo 20W Universal	49.9	789000025	Acessórios de Celular	Carregadores	39	t
4	Pelicula Gel Fosca Xiaomi Redmi 10	15.9	789000004	Pelicula Gel	Fosca	34	t
45	Fone jabra com microfone	150	122330182	Fone	Microfone	10	t
31	TV Box X96 Mini 4K	249.9	789000031	TV Box e Streaming	TV Box	8	t
1	Pelicula Vidro Brilhante iPhone 11	19.9	789000001	Pelicula Vidro	Brilhante	48	t
46	Mouse logitech	50	160885108	Periféricos	Mouse	1	t
33	Chromecast 4ª Geração	349.9	789000033	TV Box e Streaming	Chromecast	1	t
16	Capa Couro Carteira + Preto Samsung A54	54.9	789000016	Capa Couro	Carteira + Preto	2	t
19	Caixa Bluetooth RGB Speaker	129.9	789000019	Acessórios de Som	Caixas Bluetooth	5	t
18	Caixa Bluetooth Mini Portátil	89.9	789000018	Acessórios de Som	Caixas Bluetooth	18	t
41	Boneca Mini Fashion	29.9	789000041	Brinquedos	Bonecos	0	t
34	Cabo HDMI 2.0 2m	39.9	789000034	TV Box e Streaming	Cabo HDMI	23	t
43	Pipa Grande Colorida	14.9	789000043	Brinquedos	Pipas	28	t
28	Suporte Veicular Magnético	34.9	789000028	Acessórios de Celular	Suporte Veicular	27	t
30	Anel de Suporte Dourado	19.9	789000030	Acessórios de Celular	Anel de Suporte	10	t
27	Cabo Lightning iPhone Original Style	39.9	789000027	Acessórios de Celular	Cabo USB	48	t
47	caneca bonita	50	775242581	Brinquedos	Brinquedos	10	t
36	Boneco Mini Vingadores	24.9	789000036	Brinquedos	Bonecos	36	t
39	Mini Bola Antiestresse	7.9	789000039	Brinquedos	Slime	28	t
2	Pelicula Vidro Fosca Samsung A32	17.9	789000002	Pelicula Vidro	Fosca	18	t
9	Capa Silicone Vermelha Xiaomi Note 12	24.9	789000009	Capa Silicone	Vermelha	37	t
\.


--
-- TOC entry 4965 (class 0 OID 32834)
-- Dependencies: 228
-- Data for Name: sale_items; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sale_items (sale_item_id, sale_id, product_id, product_name, barcode, unit_price, quantity, total) FROM stdin;
1	1	30	Anel de Suporte Dourado	789000030	19.90	1	19.90
2	2	30	Anel de Suporte Dourado	789000030	19.90	1	19.90
3	3	34	Cabo HDMI 2.0 2m	789000034	39.90	1	39.90
4	3	16	Capa Couro Carteira + Preto Samsung A54	789000016	54.90	10	549.00
5	3	19	Caixa Bluetooth RGB Speaker	789000019	129.90	10	1299.00
6	4	41	Boneca Mini Fashion	789000041	29.90	1	29.90
7	4	12	Capa Acrílico Transparente iPhone 14	789000012	32.90	1	32.90
8	4	32	TV Box MXQ Pro 5G	789000032	229.90	8	1839.20
9	5	27	Cabo Lightning iPhone Original Style	789000027	39.90	1	39.90
10	6	30	Anel de Suporte Dourado	789000030	19.90	1	19.90
11	7	27	Cabo Lightning iPhone Original Style	789000027	39.90	1	39.90
12	8	30	Anel de Suporte Dourado	789000030	19.90	1	19.90
13	9	27	Cabo Lightning iPhone Original Style	789000027	39.90	1	39.90
14	11	9	Capa Silicone Vermelha Xiaomi Note 12	789000009	24.90	1	24.90
15	11	43	Pipa Grande Colorida	789000043	14.90	1	14.90
16	11	28	Suporte Veicular Magnético	789000028	34.90	1	34.90
17	11	2	Pelicula Vidro Fosca Samsung A32	789000002	17.90	10	179.00
18	11	31	TV Box X96 Mini 4K	789000031	249.90	1	249.90
19	11	1	Pelicula Vidro Brilhante iPhone 11	789000001	19.90	1	19.90
20	11	39	Mini Bola Antiestresse	789000039	7.90	1	7.90
21	11	2	Pelicula Vidro Fosca Samsung A32	789000002	17.90	1	17.90
22	12	9	Capa Silicone Vermelha Xiaomi Note 12	789000009	24.90	1	24.90
23	12	43	Pipa Grande Colorida	789000043	14.90	1	14.90
24	12	28	Suporte Veicular Magnético	789000028	34.90	1	34.90
25	12	2	Pelicula Vidro Fosca Samsung A32	789000002	17.90	10	179.00
26	12	31	TV Box X96 Mini 4K	789000031	249.90	1	249.90
27	12	1	Pelicula Vidro Brilhante iPhone 11	789000001	19.90	1	19.90
28	12	39	Mini Bola Antiestresse	789000039	7.90	1	7.90
29	12	2	Pelicula Vidro Fosca Samsung A32	789000002	17.90	1	17.90
30	13	41	Boneca Mini Fashion	789000041	29.90	1	29.90
31	14	36	Boneco Mini Vingadores	789000036	24.90	1	24.90
32	15	36	Boneco Mini Vingadores	789000036	24.90	1	24.90
33	16	41	Boneca Mini Fashion	789000041	29.90	1	29.90
34	17	9	Capa Silicone Vermelha Xiaomi Note 12	789000009	24.90	1	24.90
35	18	17	Capa Couro Carteira + Vermelho iPhone 11	789000017	54.90	1	54.90
36	18	44	Carrinho Hot Wheels Genérico	789000044	11.90	1	11.90
37	18	29	Power Bank 10.000mAh	789000029	119.90	11	1318.90
38	19	18	Caixa Bluetooth Mini Portátil	789000018	89.90	1	89.90
39	19	10	Capa Silicone Anti Impacto + Preta iPhone 13	789000010	29.90	20	598.00
40	19	33	Chromecast 4ª Geração	789000033	349.90	3	1049.70
41	20	41	Boneca Mini Fashion	789000041	29.90	1	29.90
42	21	34	Cabo HDMI 2.0 2m	789000034	39.90	1	39.90
43	22	18	Caixa Bluetooth Mini Portátil	789000018	89.90	1	89.90
44	23	34	Cabo HDMI 2.0 2m	789000034	39.90	1	39.90
45	24	36	Boneco Mini Vingadores	789000036	24.90	1	24.90
46	25	30	Anel de Suporte Dourado	789000030	19.90	1	19.90
47	26	24	Cabo P2 Macho-Macho 1,5m	789000024	19.90	1	19.90
48	26	17	Capa Couro Carteira + Vermelho iPhone 11	789000017	54.90	10	549.00
49	26	20	Fone de Ouvido Bluetooth JBL Style	789000020	59.90	20	1198.00
50	27	30	Anel de Suporte Dourado	789000030	19.90	1	19.90
51	27	30	Anel de Suporte Dourado	789000030	19.90	34	676.60
52	27	41	Boneca Mini Fashion	789000041	29.90	18	538.20
\.


--
-- TOC entry 4959 (class 0 OID 32808)
-- Dependencies: 222
-- Data for Name: sales; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sales (sale_id, customer_id, total_amount, discount_amount, final_amount, sale_date, sale_time, payment_method, seller_id, sale_notes) FROM stdin;
3	2	1887.90	450.00	1437.90	2025-10-29	20:01:48	Dinheiro	3	Desconto aprovado pelo doninho por ligação
4	2	1902.00	550.00	1352.00	2025-10-29	20:43:13	Dinheiro	2	Teste de outro pc
5	2	39.90	30.00	9.90	2025-10-29	21:38:26	Dinheiro	2	Desconto aprovado pelo dolinho por telefone
6	1	19.90	0.00	19.90	2025-10-29	22:14:57	Débito	2	Teste do customer balcão
7	1	39.90	0.00	39.90	2025-10-30	09:35:17	Dinheiro	3	
8	1	19.90	0.00	19.90	2025-10-30	09:45:22	Dinheiro	1	
9	1	39.90	0.00	39.90	2025-10-30	09:47:11	Conta	2	
1	1	19.90	0.00	19.90	2025-10-29	18:48:49	Dinheiro	3	
2	1	19.90	0.00	19.90	2025-10-29	19:46:21	Dinheiro	3	
11	2	549.30	40.00	509.30	2025-11-02	14:23:36	Dinheiro	2	Teste de venda real.
12	2	549.30	40.00	509.30	2025-11-02	17:16:13	Dinheiro	2	Teste de venda real.
13	1	29.90	0.00	29.90	2025-11-02	17:27:16	Dinheiro	3	
14	1	24.90	0.00	24.90	2025-11-02	17:28:39	Dinheiro	3	
15	1	24.90	0.00	24.90	2025-11-02	17:29:31	Dinheiro	2	
16	1	29.90	0.00	29.90	2025-11-02	17:31:34	Dinheiro	3	
17	1	24.90	0.00	24.90	2025-11-02	17:32:51	Dinheiro	3	
18	2	1385.70	300.00	1085.70	2025-11-02	17:36:24	Dinheiro	3	Teste da nota
19	2	1737.60	300.00	1437.60	2025-11-02	17:41:34	Dinheiro	2	Doni autorizou o desconto
20	1	29.90	0.00	29.90	2025-11-02	17:42:28	Dinheiro	2	
21	1	39.90	0.00	39.90	2025-11-02	17:43:35	Dinheiro	2	
22	1	89.90	0.00	89.90	2025-11-02	17:44:10	Dinheiro	1	
23	1	39.90	0.00	39.90	2025-11-02	17:45:02	Dinheiro	2	
24	1	24.90	0.00	24.90	2025-11-02	17:47:12	Dinheiro	2	
25	1	19.90	0.00	19.90	2025-11-02	17:49:08	Dinheiro	1	
26	2	1766.90	300.00	1466.90	2025-11-02	17:53:16	Dinheiro	2	Desconto aprovado
27	2	1234.70	150.00	1084.70	2025-11-02	18:01:10	Dinheiro	3	Aprovado pela barbara
\.


--
-- TOC entry 4981 (class 0 OID 0)
-- Dependencies: 229
-- Name: cash_movements_movement_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.cash_movements_movement_id_seq', 26, true);


--
-- TOC entry 4982 (class 0 OID 0)
-- Dependencies: 217
-- Name: customers_customerid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.customers_customerid_seq', 2, true);


--
-- TOC entry 4983 (class 0 OID 0)
-- Dependencies: 219
-- Name: employees_employeeid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employees_employeeid_seq', 3, true);


--
-- TOC entry 4984 (class 0 OID 0)
-- Dependencies: 225
-- Name: product_group_group_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.product_group_group_id_seq', 10, true);


--
-- TOC entry 4985 (class 0 OID 0)
-- Dependencies: 223
-- Name: product_subgroup_subgroup_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.product_subgroup_subgroup_id_seq', 33, true);


--
-- TOC entry 4986 (class 0 OID 0)
-- Dependencies: 215
-- Name: products_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.products_id_seq', 47, true);


--
-- TOC entry 4987 (class 0 OID 0)
-- Dependencies: 227
-- Name: sale_items_sale_item_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sale_items_sale_item_id_seq', 52, true);


--
-- TOC entry 4988 (class 0 OID 0)
-- Dependencies: 221
-- Name: sales_sale_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sales_sale_id_seq', 27, true);


--
-- TOC entry 4808 (class 2606 OID 32851)
-- Name: cash_movements cash_movements_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cash_movements
    ADD CONSTRAINT cash_movements_pkey PRIMARY KEY (movement_id);


--
-- TOC entry 4792 (class 2606 OID 24588)
-- Name: customers customers_customerdocument_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.customers
    ADD CONSTRAINT customers_customerdocument_key UNIQUE (customerdocument);


--
-- TOC entry 4794 (class 2606 OID 24586)
-- Name: customers customers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.customers
    ADD CONSTRAINT customers_pkey PRIMARY KEY (customerid);


--
-- TOC entry 4796 (class 2606 OID 32776)
-- Name: employees employees_employeelogin_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees
    ADD CONSTRAINT employees_employeelogin_key UNIQUE (employeelogin);


--
-- TOC entry 4798 (class 2606 OID 32774)
-- Name: employees employees_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees
    ADD CONSTRAINT employees_pkey PRIMARY KEY (employeeid);


--
-- TOC entry 4804 (class 2606 OID 32832)
-- Name: product_group product_group_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_group
    ADD CONSTRAINT product_group_pkey PRIMARY KEY (group_id);


--
-- TOC entry 4802 (class 2606 OID 32825)
-- Name: product_subgroup product_subgroup_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product_subgroup
    ADD CONSTRAINT product_subgroup_pkey PRIMARY KEY (subgroup_id);


--
-- TOC entry 4790 (class 2606 OID 16417)
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (id);


--
-- TOC entry 4806 (class 2606 OID 32840)
-- Name: sale_items sale_items_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sale_items
    ADD CONSTRAINT sale_items_pkey PRIMARY KEY (sale_item_id);


--
-- TOC entry 4800 (class 2606 OID 32818)
-- Name: sales sales_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sales
    ADD CONSTRAINT sales_pkey PRIMARY KEY (sale_id);


-- Completed on 2025-11-03 20:41:51

--
-- PostgreSQL database dump complete
--

