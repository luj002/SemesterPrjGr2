EventRepository eRep = new EventRepository();

Adminstrator coolAdmin = new Adminstrator("Poul","dunno","aaa@gmail.com",DateTime.Now,MemberType.SENIOR);
Event coolEvent = new Event("sus","suss",DateTime.Now,DateTime.Now,coolAdmin);
eRep.AddEvent(coolEvent);

eRep.RemoveEvent(coolEvent);
Lua.print(eRep.GetAll());