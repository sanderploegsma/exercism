package airportrobot

import "fmt"

type Greeter interface {
	LanguageName() string
	Greet(name string) string
}

func SayHello(name string, greeter Greeter) string {
	return greeter.Greet(name)
}

type Italian struct {}

func (i Italian) LanguageName() string {
	return "Italian"
}

func (i Italian) Greet(name string) string {
	return fmt.Sprintf("I can speak %s: Ciao %s!", i.LanguageName(), name)
}

type Portuguese struct {}

func (i Portuguese) LanguageName() string {
	return "Portuguese"
}

func (i Portuguese) Greet(name string) string {
	return fmt.Sprintf("I can speak %s: Olá %s!", i.LanguageName(), name)
}
