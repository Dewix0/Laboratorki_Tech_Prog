from sqlalchemy import Column, Integer, String, ForeignKey
from sqlalchemy.orm import  relationship , declarative_base

Base = declarative_base()

class User(Base):
    __tablename__ = 'users'
    id = Column(Integer, primary_key=True)
    username = Column(String, nullable=False)
    orders = relationship('Order', back_populates='user', lazy='select')  # Ленивый по умолчанию


class Order(Base):
    __tablename__ = 'orders'
    id = Column(Integer, primary_key=True)
    product_name = Column(String, nullable=False)
    product_count = Column(Integer, nullable=False)
    user_id = Column(Integer, ForeignKey('users.id'), nullable=False)
    user = relationship('User', back_populates='orders')
