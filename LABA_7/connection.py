from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker

DATABASE_URL = "sqlite:///app.db"
engine = create_engine(DATABASE_URL, echo=True)  # echo=True для логирования SQL-запросов

# Создание сессии
SessionLocal = sessionmaker(bind=engine)