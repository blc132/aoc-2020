with open('input.txt') as f:
    numbers = [int(line.rstrip()) for line in f]


def part_one():
    for n1 in numbers:
        for n2 in numbers:
            if n1 + n2 == 2020:
                print(n1*n2)
                return


def part_two():
    for n1 in numbers:
        for n2 in numbers:
            for n3 in numbers:
                if n1 + n2 + n3 == 2020:
                    print(n1*n2*n3)
                    return


# part_one()
part_two()
