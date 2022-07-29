# Vostok.Logging.NUnit

Адаптер восточного лога для NUnit.

Логи могут быть записаны в:
1) Контекст теста, который выполняется сейчас. Контекст берется из AsyncLocal. Подходит для стандартных тестов.
2) В контекст теста, в котором был создан лог. Подходит, для локально поднятых сервисов и других мест, где AsyncLocal-контекст теряется или отсутствует).

---

1) Запись лога в контекст теста, который выполняется сейчас:

а) ILog log = new NUnitTextWriterLog(new NUnitAsyncLocalTextWriterProvider());

б) serviceCollection.AddContextualNUnitLog()


2) Запись лога в контекст теста, в котором был создан лог:

а) ILog log = new NUnitTextWriterLog(new NUnitTestContextTextWriterProvider(TestExecutionContext.CurrentContext));

б) serviceCollection.AddBoundNUnitLog()

