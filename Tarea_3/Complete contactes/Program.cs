Console.WriteLine("Bienvenido a mi lista de Contactes");



//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    try
    {
        Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
        Console.WriteLine("Digite el número de la opción deseada");
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
        int typeOption = Convert.ToInt32(Console.ReadLine());

        switch (typeOption)
        {
            case 1:
                {

                    AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

                }
                break;
            case 2: //extract this to a method
                {
                    viewAllContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

                }
                break;
            case 3: //search
                {
                    try
                    {
                        int selectOption = 0;


                        Console.WriteLine("Seleccione La manera para buscar contacto.");
                        Console.WriteLine("1. ID, 2. Nombre o apellido ");
                        selectOption = Convert.ToInt32(Console.ReadLine());
                        if (selectOption != 1 || selectOption != 2)
                        {
                            Console.WriteLine("ingrese una opcion correcta de la que se muestra");
                            Console.WriteLine("-------------------------------------------------------\n");

                        }
                        else if (selectOption == 1)
                        {
                            try
                            {
                                Console.WriteLine("ingrese el id");
                                var selectedId = int.Parse(Console.ReadLine());
                                if (ids.Contains(selectedId))
                                {
                                    ShowContact(selectedId, ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                                }
                                else
                                {
                                    Console.WriteLine($"No existe contacto con el Id selecionado: {selectedId}");
                                    Console.WriteLine("-------------------------------------------------------\n");

                                }
                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("El ID Ingresado debe ser un valor entero (ej; 1,2,3)");
                            }   Console.WriteLine("-------------------------------------------------------\n");
                        }
                        else if (selectOption == 2)
                        {
                            Console.WriteLine("ingrese el Nombre o apellido");
                            var typeNameOrLastName = Console.ReadLine().ToLower();

                            bool FoundContact = false;
                            foreach (var id in ids)
                            {
                                if (ids.Count > 0)
                                {
                                    try
                                    {
                                        if (names[id].ToLower().Contains(typeNameOrLastName) || lastnames[id].ToLower().Contains(typeNameOrLastName))
                                        {
                                            ShowContact(id, ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                                            FoundContact = true;
                                        }
                                    }
                                    catch (KeyNotFoundException)
                                    {
                                        Console.WriteLine($"error al acceder al ID{id}");
                                    }
                                }

                            }

                            if (!FoundContact)
                            {
                                Console.WriteLine($"No existe contacto con el siguiente nombre o apellido selecionado: {typeNameOrLastName}");
                            }
                        }

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"debes ingresar una de las opciones de busqueda disponibles {ex.Message}" );
                        Console.WriteLine("-----------------------------------------------------------------x\n");
                    }
                }
                break;
            case 4: //modify

                {
                    Console.Write("Seleccione El id del contacto que desea actualizar:");
                    var selectedId = int.Parse(Console.ReadLine());
                    UpdateContact(selectedId, ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                }
                break;
            case 5: //delete
                {
                    try {
                        Console.Write("Seleccione El id del contacto que desea Eliminar:");
                        var selectedId = int.Parse(Console.ReadLine());
                        DeleteContact(selectedId, ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Ingresa un numero entero y ID valido");
                    }
                }
                break;
            case 6:
                runing = false;
                break;
            default:
                Console.WriteLine("Tu eres o te haces el idiota?");
                break;
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine($"ha ocurrido un error inesperado{ex.Message}");
        Console.WriteLine("Presiona ENTER para continuar");
    }


    static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        try
        {
            Console.WriteLine("Digite el nombre de la persona");
            string name = Console.ReadLine();
            Console.WriteLine("Digite el apellido de la persona");
            string lastname = Console.ReadLine();
            Console.WriteLine("Digite la dirección");
            string address = Console.ReadLine();
            Console.WriteLine("Digite el telefono de la persona");
            string phone = Console.ReadLine();
            Console.WriteLine("Digite el email de la persona");
            string email = Console.ReadLine();
            Console.WriteLine("Digite la edad de la persona en números");
            int age = 0;
            try
            {
                 age = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("ingrese un valor valido(que sea entero)");
            }
            Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

            bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

            var id = ids.Count + 1;
            ids.Add(id);
            names.Add(id, name);
            lastnames.Add(id, lastname);
            addresses.Add(id, address);
            telephones.Add(id, phone);
            emails.Add(id, email);
            ages.Add(id, age);
            bestFriends.Add(id, isBestFriend);
            Console.Clear();
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error al añadir el contacto: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
        }
    }

    static void viewAllContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine($"ID      Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
        Console.WriteLine($"____________________________________________________________________________________________________________________________");
        foreach (var id in ids)
        {
            var isBestFriend = bestFriends[id];

            string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
            Console.WriteLine($"{id}  {names[id]}       {lastnames[id]}       {addresses[id]}       {telephones[id]}        {emails[id]}         {ages[id]}          {isBestFriendStr}");
        }
        Console.ReadKey();
        Console.Clear();
    }

    static void SearchContact(int selectedId, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends, out string name, out string lastname, out string address, out string phone, out string email, out int age, out string bestFriend)
    {
    
        
            name = names[selectedId];
            lastname = lastnames[selectedId];
            address = addresses[selectedId];
            phone = telephones[selectedId];
            email = emails[selectedId];
            age = ages[selectedId];
            bestFriend = (bestFriends[selectedId] == true) ? "Si " : "No";
        

    
    }

    static void viewSelectContact(string? name, string? lastname, string? address, string? phone, string? email, int? age, string? isBestFriend, int? id)
    {
        Console.WriteLine($"los datos del contacto seleccionado que pertenece al ID {id} son:");
        Console.WriteLine($"Nombre: {name}");
        Console.WriteLine($"Apellido: {lastname}");
        Console.WriteLine($"Dirrecion: {address}");
        Console.WriteLine($"telefono: {phone}");
        Console.WriteLine($"Correo: {email}");
        Console.WriteLine($"Edad: {age}");
        Console.WriteLine($"es contacto de emergencia: {isBestFriend}");
    }

    static void ShowContact(int selectedId, List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        try { 
        string name, lastName, address, phone, email, bestFriend;
        int age;

        SearchContact(selectedId, names, lastnames, addresses, telephones, emails, ages, bestFriends, out name, out lastName, out address, out phone, out email, out age, out bestFriend);


        viewSelectContact(name, lastName, address, phone, email, age, bestFriend, selectedId);
        Console.ReadKey();
        Console.Clear();
        }
        catch (Exception ex) {
            Console.WriteLine($"error al mostar contacto {ex.Message}");
            Console.WriteLine("presiona enter para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
    /*
     creamos una funcion para actualiza contactos
     */
    static void UpdateContact(int selectedId, List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        string name, lastName, address, phone, email, bestFriend;
        int age;
        SearchContact(selectedId, names, lastnames, addresses, telephones, emails, ages, bestFriends, out name, out lastName, out address, out phone, out email, out age, out bestFriend);

        Console.WriteLine("Presiona enter para omitir");
        Console.WriteLine($"Ingresa un nuevo nombre para {name}");
        string checkName = Console.ReadLine();
        if (!string.IsNullOrEmpty(checkName))
        {
            name = checkName;
        }
        Console.WriteLine($"ingresa un nuevo apellido ");
        string checkLastName = Console.ReadLine();
        if (!string.IsNullOrEmpty(checkLastName))
        {
            lastName = checkLastName;
        }
        Console.WriteLine($"Ingresa una Nueva direccion ");
        string checkAddress = Console.ReadLine();
        if (!string.IsNullOrEmpty(checkAddress))
        {
            address = checkAddress;
        }
        Console.WriteLine($"ingresa un nuevo  numero de telefono");
        string checkPhone = Console.ReadLine();
        if (!string.IsNullOrEmpty(checkPhone))
        {
            phone = checkPhone;
        }
        Console.WriteLine($"Ingresa un nuevo correo electronico ");
        string checkEmail = Console.ReadLine();
        if (!string.IsNullOrEmpty(checkEmail))
        {
            email = checkEmail;
        }
        Console.WriteLine($"ingresa una nueva edad");
        string checkAge = Console.ReadLine();
        if (!string.IsNullOrEmpty(checkAge))
        {
            int Values = Convert.ToInt32(checkAge);
            age = Values;
        }
        Console.WriteLine($"quieres convertir el contacto como contacto de emergencia (1.Si 2.No)");
        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

        names[selectedId] = name;
        lastnames[selectedId] = lastName;
        addresses[selectedId] = address;
        telephones[selectedId] = phone;
        emails[selectedId] = email;
        ages[selectedId] = age;
        bestFriends[selectedId] = isBestFriend;

        Console.Clear();
    }

    //creamos una funcion para eliminar contactos
    static void DeleteContact(int selectedId, List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        try
        {
            string name, lastName, address, phone, email, bestFriend;
            int age;
            SearchContact(selectedId, names, lastnames, addresses, telephones, emails, ages, bestFriends, out name, out lastName, out address, out phone, out email, out age, out bestFriend);

            Console.WriteLine("Esta seguro de eliminar el contacto? (Responde con 'S' para si. Y con 'N' para No)");
            var confirmSelected = Console.ReadLine();
            if (confirmSelected.ToLower() == "s")
            {
                if (!ids.Contains(selectedId))
                {
                    Console.WriteLine("No se encontro contacto con el id indicado");
                }
                try {
                    names.Remove(selectedId);
                    lastnames.Remove(selectedId);
                    addresses.Remove(selectedId);
                    telephones.Remove(selectedId);
                    emails.Remove(selectedId);
                    ages.Remove(selectedId);
                    bestFriends.Remove(selectedId);
                    ids.Remove(selectedId);

                    for (int i = 0; i < ids.Count; i++)
                    {
                        int currentId = ids[i];
                        if (currentId > selectedId)
                        {
                        }
                        var newId = currentId - 1;

                        string tempName = names[currentId];
                        string tempLastname = lastnames[currentId];
                        string tempAddress = addresses[currentId];
                        string tempPhone = telephones[currentId];
                        string tempEmail = emails[currentId];
                        int TempAge = ages[currentId];
                        bool TempBestFriend = (bestFriends[currentId]);


                        names.Remove(currentId);
                        lastnames.Remove(currentId);
                        addresses.Remove(currentId);
                        telephones.Remove(currentId);
                        emails.Remove(currentId);
                        ages.Remove(currentId);
                        bestFriends.Remove(currentId);
                        ids.Remove(currentId);

                        names.Add(newId, tempName);
                        lastnames.Add(newId, tempLastname);
                        addresses.Add(newId, tempAddress);
                        telephones.Add(newId, tempPhone);
                        emails.Add(newId, tempEmail);
                        ages.Add(newId, TempAge);
                        bestFriends.Add(newId, TempBestFriend);

                        ids[i] = newId;

                    }
                    Console.WriteLine("Contacto corrrectamente eliminado");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error al reorganizar los contactos: {ex.Message}");
                }
          }
                
            else
            {
                Console.WriteLine("Operacion cancelada");
                Console.ReadKey();
                Console.Clear();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar el contacto: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }



}


