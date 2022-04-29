Feature: Create Truck

    @CreateTruck
    @Success
    Scenario: Create Truck Success
        Given the model <Model>
        And model year <ModelYear>
        And Manufactory year <ManufactoryYear>
        When a request for create truck is require
        And is Valid
        Then the truck must create
        Examples:
            | Model | ModelYear | ManufactoryYear |
            | 1     | 2025      | 2022            |
            | 2     | 2025      | 2022            |

    @CreateTruck
    @Failed
    Scenario: Create Truck Failed
        Given the model <Model>
        And model year <ModelYear>
        And Manufactory year <ManufactoryYear>
        When a request for create truck is require
        And is Invalid
        Then the truck is not create
        Examples:
            | Model | ModelYear | ManufactoryYear |
            | 3     | 2019      | 2020            |
            | 4     | 2017      | 2019            |