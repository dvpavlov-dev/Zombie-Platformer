# Точка входа
В этом проекте использована единая точка входа для полного управления жизненным циклом работы игры. На сцене есть объект “Game”, на нем есть компонент с таким же названием. Данный компонент запускает игру, создает State Machine игры и устанавливает первый State. 

В данной игре созданы 2 state:  
1) StartGame (создает игрока, запускает спавнер противников)  
2) EndGame (показывает меню после смерти персонажа)

# Компоненты актеров
Для игрока отдельно созданы компоненты для движения и атаки, для противников создан компонент для движения, реагирования на урон и отображения кол-во жизней. Также созданы контроллеры “Player” и “Enemy” для донастройки компонентов и реагирования на внешние воздействия.  

Для игрока и врагов были созданы отдельные конфиги для управления ключевыми параметрами актеров.  

Были созданы 5 видов зомби:  
Base enemy - обычный зомби, средняя скорость, средняя живучесть  
Advance enemy - улучшенный зомби, средняя скорость, выше среднего живучесть  
Elite enemy - элитный зомби, средняя скорость, высокая живучесть  
Tank enemy - толстый зомби, низкая скорость, чрезвычайная живучесть  
Fast enemy - быстрый зомби, высокая скорость, низкая живучесть  

# Использование Zenject
В проекте использовался Zenject для проброса ключевых классов в объекты. Были созданы фабрики для актеров на сцене, для пуль (с использованием пула объектов) и для дропа. Еще Zenject используется для конфигов, отслеживания нажатия клавиш, отслеживания процесса игры, спавнера врагов и для работы с UI.  
# Внешнее окружение
Внешнее окружение поделено на 3 блока, каждый из блоков можно менять, добавляя дополнительные элементы (такие как машины и блоки зданий). Задний фон (серый силуэт города) постепенно смещается с движением персонажа (был применен эффект параллакса). По краям поставлены заграждения в виде невидимых блоков с коллайдерами, чтобы игрок не мог убежать за край сцены.  
# Паттерны проектирования
В проекте были использованы паттерны State Machine, Factory, Objects Pool, Observer.  
# Анимации и звуки
Были созданы анимации на основе представленных материалов, звуки взяты из свободных источников. При смерти зомби проигрывается рандомно один из 3-х звуков. Также звук был добавлен для стрельбы, смерти игрока и поднятия дропа.  
