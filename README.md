# Mabel Time
### ¿Que es Mabel Time?
Mabel Time es un sistema de hora basado en el formato de hora estandar diseñado para integrarse con Mabel State Machine.
Sin embargo este trabaja de una forma independiente y puede ser usado para cualquier cosa.

**Caracteristicas principales:**
- Permite crear ciclos de dias completos
- Poco codigo es necesario para hacerlo funcionar
- Facilidad para guardar los datos de hora.
- Puede ser usado como flotante debido a su operador implicito float
- Permite hacer un debug de la hora actual sin necesidad de extraer los datos con la funcion .ToString().
 
### **Metodos:**
Los siguientes metodos pueden ser llamados desde cualquier script externo sin necesidad de hacerlo desde el contenedor del MabelTime

**public void UpdateTime(float scale)**
Se encarga de actualizar la hora.
El parametro scale cumple una funcion similar al de Time.timeScale ya que esta permite acelerar el paso del tiempo o retrasarlo

**public void UpdateTime()**
Se encarga de actualizar la hora en tiempo real.

**public void SetTime(int hour, int minutes, int seconds)**
Se encarga de establecer la hora (Se puede usar en cualquier momento y no afecta a los demas parametros como la escala del tiempo o el multiplicador de velocidad)

**public void SetSpeedMultiplier(float multiplier)**
Se encarga de establecer el multiplicador de velocidad, similar a la escala del tiempo solo que establece un valor persistente

### **Ejemplo de uso:**

    using UnityEngine;
    using Mabel.Timing; //Necesario para usar el componente 

    public class Test : MonoBehaviour
    {
        public MabelTime time = new MabelTime();
        
        void Start(){
            time.SetSpeedMultiplier(90000);
        }
        
        void Update()
        {
            time.UpdateTime();
            
            Debug.log(time); 
            //Resultado : 0, Minutes : 0, Seconds : 1
            
            time.SetTime(6,45,25);
            
            Debug.log((float)time);
            //Resultado : 0,2812f
        }
    }

