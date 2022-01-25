def remove_duplicates(lista):
# -- Start of function
#   lista2 = [] <-- Orig had an empty "lista2"
    lista2 = [2,4,6] # <- Pre-populate lista2 for different behavior
    for item in lista:
        if item not in lista2: #is item in lista2 already?
            lista2.append(item)
        else:
            print ("Item ", item, " already in lista2; item not added.")
    return lista2
# -- End of function
print("Here is the list, with unique values: ", remove_duplicates([1,2,3,3]))

# Sample output:
# C:\scripts>py removedup.py
# Item  2  already in lista2; item not added.
# Item  3  already in lista2; item not added.
# Here is the list, with unique values: [2, 4, 6, 1, 3]
