from models import Base,User,Order
from connection import SessionLocal,engine
from sqlalchemy.orm import joinedload
from colorama import Fore, Style


def main():


    print(f"{Fore.GREEN}Пересоздание таблиц....{Style.RESET_ALL}")

    Base.metadata.drop_all(bind=engine)
    Base.metadata.create_all(bind=engine)

    print(f"{Fore.GREEN}Выполнено{Style.RESET_ALL}")
    print("")
    
    session = SessionLocal()

    try:
        user1 = User(username='Daniil')
        user2 = User(username='Pasha')
        user3 = User(username='StariyBog')
        session.add_all([user1, user2,user3])
        print(f"{Fore.GREEN}Committing users...{Style.RESET_ALL}")
        session.commit()

        print(f"{Fore.GREEN}Committing ended...{Style.RESET_ALL}")

        # Добавление заказа для пользователя
        order1 = Order(product_name='Laptop', product_count=1, user_id=user1.id)
        order2 = Order(product_name='Лазеры из глаз',product_count=2,user_id=user3.id)
        order3 = Order(product_name='Лазеры из глаз',product_count=2,user_id=user2.id)
        order4 = Order(product_name='Пашина рубашка',product_count=2,user_id=user2.id)
        session.add_all([order1,order2,order3,order4])
        print(f"{Fore.GREEN}Committing order...{Style.RESET_ALL}")
        session.commit()
        print(f"{Fore.GREEN}Committing ended...{Style.RESET_ALL}")


        print(f"{Fore.RED}Lazy{Style.RESET_ALL}")

        all_users=session.query(User).all()
        for user in all_users:
            print(f"{Fore.YELLOW}User:{user.username}{Style.RESET_ALL}")
            print(f"{Fore.YELLOW}User:{user.orders}{Style.RESET_ALL}")

        print("")
        print(f"{Fore.RED}Eager{Style.RESET_ALL}")
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