from models import Base,User,Order
from connection import SessionLocal,engine
from sqlalchemy.orm import joinedload
from colorama import Fore, Style


def main():
    # Создаем базу данных и таблицы
    Base.metadata.drop_all(bind=engine)
    Base.metadata.create_all(bind=engine)

    # Создаем сессию
    session = SessionLocal()

    try:
        # Создание пользователей
        user1 = User(username='Alice')
        user2 = User(username='Bob')
        session.add_all([user1, user2])
        print(f"{Fore.GREEN}Committing users...{Style.RESET_ALL}")
        session.commit()

        print(f"{Fore.GREEN}Committing ended...{Style.RESET_ALL}")

        # Добавление заказа для пользователя
        order1 = Order(product_name='Laptop', product_count=1, user_id=user1.id)
        session.add(order1)
        print(f"{Fore.GREEN}Committing order...{Style.RESET_ALL}")
        session.commit()
        print(f"{Fore.GREEN}Committing ended...{Style.RESET_ALL}")


        print(f"{Fore.RED}Все пользователи{Style.RESET_ALL}")

        all_users=session.query(User).all()
        for user in all_users:
            print(f"{Fore.YELLOW}User:{user.username}{Style.RESET_ALL}")

        print("")
        print(f"{Fore.RED}Пользователи с заказами{Style.RESET_ALL}")
         # Загрузка пользователей с их заказами (EAGER loading)
        users_with_orders = session.query(User).options(joinedload(User.orders)).all()

        for user in users_with_orders:
            print(f"{Fore.YELLOW}User: {user.username}{Style.RESET_ALL}")
            print(f"{Fore.YELLOW}Orders:{Style.RESET_ALL}")
            for order in user.orders:
                print(f"{Fore.YELLOW}- Product: {order.product_name}, Count: {order.product_count}{Style.RESET_ALL}")
    finally:
        session.close()

if __name__ == "__main__":
    main()