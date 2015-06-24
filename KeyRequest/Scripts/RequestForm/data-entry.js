$(document).ready(function () {
    // Setup DateTimePicker plugin if needed    
    if (!Modernizr.inputtypes.date) {
        $('.datepicker').datetimepicker({
            format: 'MM/DD/YYYY',
        });

        $(document).on('touch click', '*[data-datepicker="true"] .input-group-addon', function (e) {
            $('input', $(this).parent()).focus();
        });
    }

    $("#requestsets").on('change', 'select', function () {
        dataEntry.refreshSelectGroup('#requestsets select');
    });
    $("#requestsets").on('click', 'thead button', function () {
        dataEntry.appendSetTable();
        dataEntry.refreshSelectGroup('#requestsets select');
    });
    $("#requestsets").on('click', 'tbody button', function () {
        rowIndex = $(this).parents('tr').index();

        dataEntry.trimSetTable(rowIndex);
        dataEntry.refreshSelectGroup('#requestsets select');
    });

    refreshSetTable();
});


var dataEntry = (function ($) {
    var me = {};

    me.refreshSetTable = function () {
        $("#requestsets tbody tr:gt(0) button").toggleClass('disabled', false);
        me.refreshSelectGroup('#requestsets select');
    }

    me.appendSetTable = function () {
        $parent = $("#requestsets tbody");
        $newRow = $parent.find("tr:last").clone();

        $newRow.find('select,input').not('[type="hidden"]').val([]);
        $newRow.find("button").toggleClass('disabled', false);

        newRowIdx = $parent.find("tr").length;
        me.setInputIDs($newRow, newRowIdx);

        $parent.append($newRow);
    }

    me.trimSetTable = function (rowIdx) {
        $parent = $("#requestsets tbody");
        $deleteRow = $parent.find("tr:eq(" + rowIdx + ")");
        $updateRows = $parent.find("tr:gt(" + rowIdx + ")");

        $deleteRow.remove();

        newRowIdx = rowIdx;
        $updateRows.each(function () {
            me.setInputIDs($(this), newRowIdx);
            newRowIdx++;
        });
    }

    me.setInputIDs = function ($parent, newRowIdx) {
        idRegex = /(Sets_)(\d+)(__.*)/;
        nameRegex = /(Sets\[)(\d+)(\]\..*)/;

        if ($parent) {
            $parent.find("select,input").each(function () {
                newId = $(this).attr("id").replace(idRegex, "$1" + newRowIdx + "$3");
                newName = $(this).attr("name").replace(nameRegex, "$1" + newRowIdx + "$3");

                $(this).attr("id", newId).attr("name", newName);

            });
        }
    }

    me.refreshSelectGroup = function (selector) {
        $selects = $(selector);

        if ($selects.length > 1) {
            $selects.find("option").removeAttr('disabled').show();

            $selects.each(function () {
                currValue = $(this).val();

                if (currValue) {
                    $selects.not(this).find("option[value=" + currValue + "]").attr('disabled', 'disabled').hide();
                }
            });

            // Refresh each dropdown
            $selects.each(function () {
                $(this).hide().show();
            });
        }
    }

    return me;
}(jQuery));