class Calculator:
    def __init__(self):
        self.stack = []
        self.token_map = {
            "+": lambda: self.push(self.pop() + self.pop()),
            "-": lambda: self.push(self.pop() - self.pop()),
            "*": lambda: self.push(self.pop() * self.pop()),
            "/": lambda: self.push(self.pop() / self.pop()),
            "=": lambda: self.print()
        }

    def push(self, sth):
        self.stack.append(int(sth))

    def pop(self):
        return self.stack.pop()

    def print(self):
        print(self.pop())

    def run(self, code):
        tokens = code.split(" ")
        c = 0
        while c < len(tokens):
            current = tokens[c]
            if current.isnumeric():
                self.push(current)
                c += 1
            elif current in self.token_map:
                self.token_map[current]()
                c += 1
            else:
                raise SyntaxError(f"{current}: Invalid syntax.")


def repl():
    calc = Calculator()
    while True:
        inpt = input("Введите выражение: ")
        calc.run(inpt)


if __name__ == "__main__":
    repl()
