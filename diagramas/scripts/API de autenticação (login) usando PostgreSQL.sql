CREATE TABLE "usuario" (
  "id" serial PRIMARY KEY,
  "nome" varchar(150) NOT NULL,
  "email" varchar(150) UNIQUE NOT NULL,
  "senha_hash" varchar(255) NOT NULL,
  "ativo" boolean DEFAULT true,
  "criado_em" timestamp DEFAULT (now()),
  "atualizado_em" timestamp
);

CREATE TABLE "role" (
  "id" serial PRIMARY KEY,
  "nome" varchar(100) UNIQUE NOT NULL,
  "descricao" text
);

CREATE TABLE "usuario_role" (
  "id" serial PRIMARY KEY,
  "usuario_id" int,
  "role_id" int
);

CREATE TABLE "token" (
  "id" serial PRIMARY KEY,
  "usuario_id" int,
  "refresh_token" varchar(300) NOT NULL,
  "expiracao" timestamp NOT NULL,
  "criado_em" timestamp DEFAULT (now()),
  "ativo" boolean DEFAULT true
);

CREATE TABLE "permissao" (
  "id" serial PRIMARY KEY,
  "nome" varchar(150) UNIQUE NOT NULL,
  "descricao" text
);

CREATE TABLE "role_permissao" (
  "id" serial PRIMARY KEY,
  "role_id" int,
  "permissao_id" int
);

ALTER TABLE "usuario_role" ADD FOREIGN KEY ("usuario_id") REFERENCES "usuario" ("id");

ALTER TABLE "usuario_role" ADD FOREIGN KEY ("role_id") REFERENCES "role" ("id");

ALTER TABLE "token" ADD FOREIGN KEY ("usuario_id") REFERENCES "usuario" ("id");

ALTER TABLE "role_permissao" ADD FOREIGN KEY ("role_id") REFERENCES "role" ("id");

ALTER TABLE "role_permissao" ADD FOREIGN KEY ("permissao_id") REFERENCES "permissao" ("id");
