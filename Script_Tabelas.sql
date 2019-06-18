CREATE TABLE "patrimonio" (
	"nome"	TEXT NOT NULL,
	"marcaid"	INTEGER NOT NULL,
	"descricao"	TEXT,
	"ntombo"	INTEGER
)

CREATE TABLE "marca" (
	"nome"	TEXT NOT NULL,
	"marcaid"	INTEGER NOT NULL UNIQUE,
	PRIMARY KEY("marcaid")
)