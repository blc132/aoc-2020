import re

with open('input.txt') as f:
    lines = [line.rstrip() for line in f]

regexDictionary = re.compile(r"\b(\w+)\s*:\s*([^:]*)(?=\s+\w+\s*:|$)")
regexHexColor = re.compile(r"^#(?:[0-9a-fA-F]{3}){1,2}$")
eyeColors = ["amb", "blu", "brn", "gry", "grn", "hzl", "oth"]

# byr (Birth Year)
# iyr (Issue Year)
# eyr (Expiration Year)
# hgt (Height)
# hcl (Hair Color)
# ecl (Eye Color)
# pid (Passport ID)
# cid (Country ID)


def validatePassport(passportData):
    d = dict(regexDictionary.findall(passportData))
    if 'byr' in d and 'iyr' in d and 'eyr' in d and 'hgt' in d and 'hcl' in d and 'ecl' in d and 'pid' in d:
        byr = int(d["byr"])
        if not (byr >= 1920 and byr <= 2002):
            return 0

        iyr = int(d["iyr"])
        if not (iyr >= 2010 and iyr <= 2020):
            return 0

        eyr = int(d["eyr"])
        if not (eyr >= 2020 and eyr <= 2030):
            return 0

        hgt = []
        if "cm" in d["hgt"]:
            hgt.append("cm")
            hgt.append(int(d["hgt"].replace("cm", "")))
        elif "in" in d["hgt"]:
            hgt.append("in")
            hgt.append(int(d["hgt"].replace("in", "")))
        if not len(hgt) or not ((hgt[0] == "cm" and hgt[1] >= 150 and hgt[1] <= 193) or (hgt[0] == "in" and hgt[1] >= 59 and hgt[1] <= 76)):
            return 0

        if not regexHexColor.match(d["hcl"]):
            return 0

        if not any(color in d["ecl"] for color in eyeColors):
            return 0

        if not (len(d["pid"]) == 9 and d["pid"].isdigit()):
            return 0

        return 1
    return 0


passportData = ""
validPassports = 0

for line in lines:
    if line == '':
        if validatePassport(passportData):
            validPassports += 1
        passportData = ""
    else:
        passportData = f'{passportData} {line}'

if validatePassport(passportData):
    validPassports += 1

print("==========")
print(validPassports)
