package aula;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class ConversorDeTempoTest {
    @Test
    void testarConversorFormatMin30To0HorasE30Minutos(){
        //Arrange
        ConversorDeTempo conv=new ConversorDeTempo();
        int minutes=30;
        StringBuilder expectedText= new StringBuilder();
        expectedText.append("0 hora(s) e 30 minuto(s)");
        //Act
        String formatedMin=conv.formatMin(minutes);
        //Assert
        assertEquals(expectedText.toString(),formatedMin);
    }

    @Test
    void testarConversorFormatMin160To2HorasE30Minutos(){
        //Arrange
        ConversorDeTempo conv=new ConversorDeTempo();
        int minutes=160;
        StringBuilder expectedText= new StringBuilder();
        expectedText.append("2 hora(s) e 40 minuto(s)");
        //Act
        String formatedMin=conv.formatMin(minutes);
        //Assert
        assertEquals(expectedText.toString(),formatedMin);
    }

    @Test
    void testarConversorFormatMin3600To12HorasE30Minutos(){
        //Arrange
        ConversorDeTempo conv=new ConversorDeTempo();
        int minutes=360;
        StringBuilder expectedText= new StringBuilder();
        expectedText.append("6 hora(s) e 0 minuto(s)");
        //Act
        String formatedMin=conv.formatMin(minutes);
        //Assert
        assertEquals(expectedText.toString(),formatedMin);
    }
}
