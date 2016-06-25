# ShopWCFknockout
Онлайн магазин. Состоит из 3 проектов:
  -data layer  - содержит poco-класс для EF, класс контекта  и класс инициализирующий БД для EF code first, интерфейс репозитория и реализацию репозитория. 
  -служба WCF - связана с data layer c помощию DI(ninject.extensions.wcf). 
  -проект asp.net mvc - обращается к data layer через службу wcf, использует knockout для визуализации представлений.
