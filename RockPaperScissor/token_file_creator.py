


def create_new_token():
    file = open("token.secret", "w+")
    token = input("Insert your discord token here: ")
    file.write(token)
    file.close()
    input("Token saved!\n")






if __name__ == "__main__":
    create_new_token()
